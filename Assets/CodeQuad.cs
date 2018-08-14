using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CodeQuad : MonoBehaviour
{
    public Color imageColor;
    public bool changeColor;

    public float scrollSpeedVerticle;
    public float scrollSpeedHorizontal;

    Material texture;
    void Start()
    {
        changeColor = false;
        texture = GetComponent<MeshRenderer>().material;

        var filter = GetComponent<MeshFilter>();
        var mesh = new Mesh();

        filter.mesh = mesh;

        //Vertices
        //Locations of vertices
        var verts = new Vector3[5];

        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(16, 0, 0);
        verts[2] = new Vector3(0, 16, 0);
        verts[3] = new Vector3(16, 16, 0);
        verts[4] = new Vector3(8, 20.5f, 0);

        mesh.vertices = verts;

        //Indicies
        //determines which vertices make up an individual triangle
        var indices = new int[9];
        //bottom tri
        indices[0] = 0;
        indices[1] = 2;
        indices[2] = 1;

        //top tri
        indices[3] = 3;
        indices[4] = 1;
        indices[5] = 2;

        //other top tri
        indices[6] = 3;
        indices[7] = 2;
        indices[8] = 4;

        mesh.triangles = indices;

        //Normals
        //describes how light bounces off the surface (at the vertex level)
        //var norms = new Vector3[5];

        //norms[0] = -Vector3.forward;
        //norms[1] = -Vector3.forward;
        //norms[2] = -Vector3.forward;
        //norms[3] = -Vector3.forward;
        //norms[4] = -Vector3.forward;

        //mesh.normals = norms;

        //UVs STs
        //defines how textures are mapped onto the surface

        var UVs = new Vector2[5];

        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(1, 0);
        UVs[2] = new Vector2(0, 1);
        UVs[3] = new Vector2(1, 1);
        UVs[4] = new Vector2(.5f,1.25f);


        mesh.uv = UVs;
    }

    private void Update()
    {
        if (changeColor == true)
        {
            texture.color = imageColor;
        }
        float verticleOffset = Time.time * scrollSpeedVerticle;
        float horizontalOffset = Time.time * scrollSpeedHorizontal;


        texture.mainTextureOffset = new Vector2(horizontalOffset, -verticleOffset);
    }
}
