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
            case 1:
                Switch();
                hasChanged = false;
                break;
        }
    }

    private void SetActive()
    {
        gameObject.SetActive(false);
        
    }

    private void Switch()
    {
        gameObject.SetActive(true);

        Vector3 currentPosition = transform.position;
        currentPosition = new Vector3(currentPosition.x + 1f, currentPosition.y,currentPosition.z);
        transform.position = currentPosition;

        Debug.Log($"문고리의 X 위치가 +8 증가하여 {transform.position.x}이(가) 되었습니다.");
    }

}