using UnityEngine;

public class Door : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0, 2);
        switch (actionIndex)
        {
            case 0:
                Rotate();
                hasChanged = false;
                break;
            case 1:
                ChangeColor();
                hasChanged = false;
                break;
        }
    }

    private void Rotate()
    {
        Vector3 currentRotation = transform.eulerAngles;
        float newRotationY = currentRotation.x - 10f;
        transform.eulerAngles = new Vector3(currentRotation.x, newRotationY, currentRotation.z);
        Debug.Log("yRotate");
        Debug.Log(transform.eulerAngles);
    }

    private void ChangeColor()
    {
        objectRenderer.material = Resources.Load<Material>("DoorColor");
    }
}
