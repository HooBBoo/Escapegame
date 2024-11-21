using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ObjectLights : Object
{
    public List<LampLight> lampLights = new List<LampLight>();
    
    void Start()
    {
        // 하위 자식에서 LampLight 컴포넌트 자동 검색 및 추가
        foreach (Transform child in transform)
        {
            LampLight lamp = child.GetComponent<LampLight>();
            if (lamp != null)
            {
                lampLights.Add(lamp);
            }
        }
    }
    
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
    }

    private IEnumerator OffLightsCoroutine()
    {
        foreach (LampLight lamp in lampLights)
        {
            if (GetComponent<Light>() != null)
            {
                GetComponent<Light>().enabled = false; //  조명 끄기
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


