using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrigger : ITriggerAction
{
    public void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone)
    {
        Object[] allObjects = GameObject.FindObjectsOfType<Object>();
        foreach (Object obj in allObjects)
        {
            obj.ResetToOriginalState();
        }

        if (!TriggerManager.Instance.isCorrectMap)
        {
            TriggerManager.Instance.FloorUp();
        }
        else
        {
            TriggerManager.Instance.FloorReset();
        }
        triggerZone.TeleportPlayer(playerTransform);
    }
}
