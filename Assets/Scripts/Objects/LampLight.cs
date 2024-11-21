using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    public Light light;
    public MeshRenderer lamp;
    private MaterialPropertyBlock propertyBlock;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        lamp = GetComponentInChildren<MeshRenderer>();
    }

    // Light & Emission 설정
    private void SetLightAndEmission(bool state)
    {
        light.enabled = state;

        lamp.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_EmissionColor", state ? Color.white * 2.0f : Color.black);
        lamp.SetPropertyBlock(propertyBlock);
    }
    
    // Light & Emission 활성화
    public void TurnOn()
    {
        SetLightAndEmission(true);
    }
    
    // Light & Emission 비활성화
    public void TurnOff()
    {
        SetLightAndEmission(false);
    }
}
