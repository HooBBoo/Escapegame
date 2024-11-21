using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ObjectLights : Object
{
    [Header("Light Objects")]
    public Light[] lights;
    public override void ExecuteRandomAction()
    {
        OffLights();
    }

    private void OffLights()
    {
        StartCoroutine(OffLightsCoroutine());
    }

    private IEnumerator OffLightsCoroutine()
    {
        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.enabled = false; //  조명 끄기
                yield return new WaitForSeconds(0.7f); // 끄는 간격
            }
        }
    }
}
}

