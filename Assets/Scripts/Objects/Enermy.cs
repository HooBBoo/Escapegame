using UnityEngine;

public class Enermy : Object
{
    public override void ExecuteRandomAction()
    {
        int actionIndex = Random.Range(0, 3);
        switch (actionIndex)
        {
            case 0:
                SetActive();
                hasChanged = false;
                break;
            case 1:
                Sound();
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
        Debug.Log("SetActiveManager");
        
    }

    private void Sound()
    {
        EventBus.Publish("ManagerSound");
        Debug.Log("SoundManager");
    }

    public void NoChange()
    {
        Debug.Log("NoChange");
        return;
    }
}
