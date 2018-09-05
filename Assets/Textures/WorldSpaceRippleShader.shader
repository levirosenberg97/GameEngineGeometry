Shader "Custom/WorldSpaceRippleShader" 
{
	Properties 
	{
		_PrimaryColor ("Primary Color", Color) = (0,0,0,0)
		_SecondaryColor("Secondary Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondaryTex("2nd Texture", 2D) = "white" {}
		_Transition ("Transition",Range(0,10)) = 0.5
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_RippleOrigin("Ripple Origin", Vector) = (0,0,0,0)
		_RippleDistance("Ripple Distance", Float) = 0
		_RippleWidth("Ripple Width", Float) = 0.1
	}


	SubShader 
		{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _SecondaryTex;		

			struct Input 
			{
				float2 uv_MainTex;
				float2 uv_SecondaryTex;
				float3 worldPos;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _PrimaryColor;
			fixed4 _SecondaryColor;
			fixed4 _RippleOrigin;
			float _RippleDistance;
			float _RippleWidth;
			half  _Transition;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

				void surf(Input IN, inout SurfaceOutputStandard o)
			{
				// Albedo comes from a texture tinted by color 
				float distance = length(IN.worldPos.xyz - _RippleOrigin.xyz) - _RippleDistance;
				float halfWidth = _RippleWidth * 0.5;
				float lowerDistance = distance - halfWidth;
				float upperDistance = distance + halfWidth;



				fixed4 mainMaskStrength = tex2D(_MainTex, IN.uv_MainTex).r;
				mainMaskStrength = mainMaskStrength * 9.8 + 0.1;
				float mainMaskSelection = (_Transition > mainMaskStrength);

				fixed4 secondMaskStrength = tex2D(_SecondaryTex, IN.uv_MainTex ).r;
				secondMaskStrength = secondMaskStrength * 9.8 + 0.1;
				float secondMaskSelection = (_Transition > secondMaskStrength);
				 
				fixed4 c = secondMaskSelection;

				//fixed4 c = fixed4(pow(1 - (abs(distance) / halfWidth), 8), 0, 0, 1);
				float ringStrength = pow(1 - (abs(distance) / halfWidth), 8)
					* (lowerDistance < 0 && upperDistance > 0);

				//o.Albedo = ringStrength * ((maskSelection * _PrimaryColor + (1 - maskSelection) * _SecondaryColor)* (secondMaskSelection * _PrimaryColor + (1 - secondMaskSelection) * _SecondaryColor));
				o.Albedo = ((mainMaskSelection * _PrimaryColor + (1 - mainMaskSelection) * _SecondaryColor)
						  * (secondMaskSelection * _PrimaryColor + (1 - secondMaskSelection) * _SecondaryColor)) ;
				o.Emission = o.Albedo;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = 1;
				//TRANSFORM_TEX(o.)
			}
			ENDCG
		}
	FallBack "Diffuse"
}
