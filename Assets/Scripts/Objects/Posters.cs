using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Posters : Object
{
    [SerializeField] private Material oppositeMaterial; // 반대되는 Material을 저장할 변수
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
        if (oppositeMaterial != null) // 반대 Material이 설정되어 있는지 확인
        {
            objectRenderer.material = oppositeMaterial; // 반대 Material로 변경
            Debug.Log($"Material Changed to {oppositeMaterial.name}");
        }
        else
        {
            Debug.LogWarning("oppositeMaterial이 설정되지 않았습니다.");
        }
    }

}
