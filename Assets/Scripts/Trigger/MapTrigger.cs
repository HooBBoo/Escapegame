using UnityEngine;
using Random = UnityEngine.Random;


public class MapTrigger : ITriggerAction
{
    public void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone) {
        bool hasChangeOccurred = false;
        
        GameObject objectWithChildren = GameObject.Find("Objects"); // 맵의 자식 오브젝트들이 있는 부모 오브젝트
        if (objectWithChildren != null)
        {
            int childCount = objectWithChildren.transform.childCount;
            if (childCount > 0)
            {
                int randomIndex = Random.Range(0, childCount);
                Transform selectedChild = objectWithChildren.transform.GetChild(randomIndex);

                // 선택된 자식 오브젝트의 기능 실행
                IChildAction childAction = selectedChild.GetComponent<IChildAction>();
                if (childAction != null)
                {
                    childAction.ExecuteRandomAction();
                    // if (!(childAction is NoChange)) {
                    //     hasChangeOccurred = true;
                    // } // 자식 오브젝트에 기능이 있다면 실행
                }
            }

            // 변화 여부에 따라 isCorrectMap 설정
            TriggerManager.Instance.isCorrectMap = !hasChangeOccurred;
        }
    }

}


