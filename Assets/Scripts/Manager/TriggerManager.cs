using UnityEngine;

public class TriggerManager : Singleton<TriggerManager>
{
    //일단 정답 트리거 부터 생각... 정답 트리거는 만약에 맵에 바뀐 오브젝트랑 기믹이 없다면 fronttrigger로 가야 통과 만약 반대로 가면 0으로 리셋
    //맵에 기믹이랑 오브젝트에 달라진게 보이면 backTrigger로 가야지 다음층으로 만약에 앞으로 갔다면 0으로 초기화 
    
    //오브젝트를 램덤으로 기믹을 보여줘야하는데 만약에 맵 랜덤 트리거에 충돌을 했다면, 그 트리거는 false해주고 
    
    public GameObject[] TriggerObjects; //trigger를 받아온다.(앞에 트리거, 뒤에 트리거, 맵 변경 트리거)
    
    
}
