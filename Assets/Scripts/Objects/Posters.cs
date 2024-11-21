using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Posters : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0, 3);
        switch (actionIndex)
        {
            case 0:
                Rotate();
                hasChanged = false;
                break;
            case 1:
                ChangeMaterial();
                hasChanged = false;
                break;
            // default:
            //     NoChange();
            //     hasChanged = true;
            //     break;
        }
    }

    private void Rotate()
    {
        Vector3 currentRotation = transform.eulerAngles;
        float newRotationX = currentRotation.x + 15f;
        transform.eulerAngles = new Vector3(newRotationX, currentRotation.y, currentRotation.z);
        Debug.Log("Rotate");
    }
    
    private void ChangeMaterial() //Meterial 교체
    {
        objectRenderer.material = Resources.Load<Material>("Paint_04");
        Debug.Log("Material Changed");
    }


    // public void NoChange()
    // {
    //     Debug.Log("NoChange");
    //     return;
    // }
    
}
