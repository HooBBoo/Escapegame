# Escapegame
 
## 📖 목차

1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [개발기간](#개발기간)
4. [구현내용](#구현)
5. [Trouble Shooting](#trouble-shooting)

 ## 👨‍🏫 프로젝트 소개

 3D 퍼즐 게임이고, 8번 출구라는 게임을 레퍼런스로 생각하면서 만들었습니다.
 0층부터 시작하여 정상적인 맵과 맵에 이상형상이 생긴 맵이 있는데
 이상형상 맵일 때는 뒤로 돌아가고, 정상적인 맵일 때는 앞으로 이동하면서
 탈출하는 게임입니다.

 [1조 프로젝트 영상]


 ## 👨🏻‍🤝‍👨🏻 팀소개
|  |이름|깃허브|
|---|---|:---|
|팀장|김재민|https://github.com/kjm0417)|
|팀원|차승민|https://github.com/SnowRabbit28)|
|팀원|김홍섭|https://github.com/qufrj7)|
|팀원|이지윤A|https://github.com/HooBBoo)|

## 개발기간

___2024. 11. 15 ~ 2024. 11. 22___


## 기능 구현 내용
1. 플레이어 이동 - walk, run, look
2. 업적 시스템 -  연속 4번 성공, 탈출 전, 연속 3번 실패, 15분전 클리어, enemySound 발생, Light 기능 발생
3. 오디오 시스템 - Walk, EnemySound
4. Trigger 시스템 - BackTrgger, FrontTrigger, MapTrigger, EndTrigger
5. 기믹 오브젝트 -  Door, DoorTransparency, Enemy, Knob, Lights, Posters, Socket
6. UI - time, floor, EndSceneUI, StartUI
7. 

## 🚀Trouble Shooting

### 1. 오브젝트 초기화 문제
해결전 코드

```cs
  public void ExecuteTrigger(Transform playerTransform, TriggerZone triggerZone)
    {
        // Scene 내에서 Object 클래스를 상속받은 모든 오브젝트를 찾는다
        Object[] allObjects = GameObject.FindObjectsOfType<Object>();
        Debug.Log($"Found {allObjects.Length} objects in the scene.");


해결 후 코드

```cs
 private List<Object> allObjects; // Object를 상속받은 오브젝트를 담는 리스트

    public MapTrigger()
    {
        // 게임 시작 시 모든 Object를 상속받은 오브젝트를 리스트에 추가
        allObjects = new List<Object>(GameObject.FindObjectsOfType<Object>(true));
    }


### 2. 연속적 업적 초기화

해결 후 코드

 public void ResetAchievement(EAchievementCode resetCode) //연속을 위해 초기화 해주는 코드
    {
        if (!achievements.ContainsKey(resetCode))// 업적이 없으면
        {
            return; // 넘기기
        }
        List<Achievement> list = achievements[resetCode]; //업적이 있으면 리스트에 넣어주고
        foreach (Achievement achievement in list)
        {
            achievement.curvalue = 0;
        }
    }


