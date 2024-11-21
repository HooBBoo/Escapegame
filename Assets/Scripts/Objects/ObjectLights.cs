using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ObjectLights : Object
{
    [Header("Light Objects")]
    public Light[] lights;
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0,2);
        switch (actionIndex)
        {
            case 0:
                OffLights();
                hasChanged = false;
                break;
            case 1:
                NoChange();
                hasChanged = true;
                break;
        }
    }

    private void OffLights()
    {
        StartCoroutine(OffLightsCoroutine());
        Debug.Log("OffLights");
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
    public void NoChange()
    {
        Debug.Log("NoChange");
        return;
    }
}


