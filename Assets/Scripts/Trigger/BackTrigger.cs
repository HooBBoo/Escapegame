using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrigger : ITriggerAction
{
    public void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone)
    {
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
