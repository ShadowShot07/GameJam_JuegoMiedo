using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccludedAudioSource : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;

    [SerializeField]
    private bool occlusionEnabled = false;

    [SerializeField]
    private string occlusionParameterName = null;

    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float occlusionIntensity = 1f;

    private float currentOcclusion = 0.0f;
    private float nextOcclusionUpdate = 0.0f;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    void Update()
    {
        if (instance.isValid())
        {
            instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(this.gameObject));
            if (!occlusionEnabled)
            {
                currentOcclusion = 0.0f;
            }
            else if (Time.time >= nextOcclusionUpdate)
            {
                nextOcclusionUpdate = Time.time + FMODUnityResonance.FmodResonanceAudio.occlusionDetectionInterval;
                float newOclusion = occlusionIntensity * FMODUnityResonance.FmodResonanceAudio.ComputeOcclusion(transform);
                //instance.setParameterByName(occlusionParameterName, currentOcclusion);
                StartCoroutine(LerpOcclusion(newOclusion));
            }
        }
    }

    private IEnumerator LerpOcclusion(float newOcclusion)
    {
        float occlusionTime = FMODUnityResonance.FmodResonanceAudio.occlusionDetectionInterval - 0.01f;
        float occlusion = 0;
    
        for (float f = 0; f <= occlusionTime; f += Time.deltaTime)
        {
            occlusion = Mathf.Lerp(currentOcclusion, newOcclusion, f / occlusionTime);
            instance.setParameterByName(occlusionParameterName, occlusion);
            yield return null;
        }
        currentOcclusion = newOcclusion;
    }
}
