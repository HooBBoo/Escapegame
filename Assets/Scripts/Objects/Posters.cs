using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posters : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0, 3);
        if (actionIndex == 0)
        {
            Rotate();
        }
        else if (actionIndex == 1)
        {
            ChangeColor();
        }
        else
        {
            return;
        }
    }

    private void Rotate()
    {
        // 포스터를 15도 회전시키는 동작
        transform.Rotate(Vector3.right, 15f);
    }

    private void ChangeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
    
}
