using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignettePulse : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;

    void Start()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void Update()
    {
        m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
