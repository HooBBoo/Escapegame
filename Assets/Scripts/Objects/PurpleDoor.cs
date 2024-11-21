using UnityEngine;

public class PulpleDoor : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0,0);
        switch (actionIndex)
        {
            case 0:
                ChangeColor();
                hasChanged = false;
                break;
            default:
                NoChange();
                hasChanged = true;
                break;
        }
    }

    private void ChangeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = new Color(0.5f, 0.0f, 0.7f);
            Debug.Log("색상이 보라색으로 변경되었습니다.");
        }
        else
        {
            Debug.LogWarning("Renderer가 없습니다. 색상을 변경할 수 없습니다.");
        }
    }

    public void NoChange()
    {
        return;
    }
}
