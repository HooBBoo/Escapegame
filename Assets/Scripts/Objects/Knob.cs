using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0, 2);
        switch (actionIndex)
        {
            case 0:
                SetActive();
                hasChanged = false;
                break;
            default:
                NoChange();
                hasChanged = true;
                break;
        }
    }

    private void SetActive()
    {
        gameObject.SetActive(false);
        Debug.Log("SetActive");
        
    }

    public void NoChange()
    {
        Debug.Log("NoChange");
        return;
    }
}
