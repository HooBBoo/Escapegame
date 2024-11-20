using UnityEngine;
public enum TriggerType
{
    FrontTrigger,
    BackTrigger,
    MapTrigger
    // 필요한 만큼 더 추가 가능
}

public interface ITriggerAction
{
    void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone);
}
public class TriggerManager : Singleton<TriggerManager>
{
    public int currentfloor=0; //현재 층
    public bool isCorrectMap = true; //맵이 정상인지
    
    public void FloorUp()
    {
        currentfloor++;
        UIManager.Instance.UINumberUpdate();
    }

    public void FloorReset()
    {
        currentfloor=0;
        UIManager.Instance.UINumberUpdate();
    }
}
