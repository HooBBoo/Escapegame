using UnityEngine;
using Random = UnityEngine.Random;


public class MapTrigger : ITriggerAction
{
    public void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone)
    {
        // Scene 내에서 ObjectScript를 상속받은 모든 오브젝트들을 찾는다
        Object[] allObjects = GameObject.FindObjectsOfType<Object>();
        Debug.Log(allObjects.Length);
        
        if (allObjects.Length > 0)
        {
            // 무작위로 하나의 ObjectScript를 선택
            int randomIndex = Random.Range(0, allObjects.Length);
            Object selectedObject = allObjects[randomIndex];

            // 선택된 ObjectScript의 기능 실행
            selectedObject.ExecuteRandomAction();
            
            // 변화 여부에 따라 isCorrectMap 설정 (변화가 없으면 True로 설정)
            TriggerManager.Instance.isCorrectMap =selectedObject.HasChanged();
        }
    }

}