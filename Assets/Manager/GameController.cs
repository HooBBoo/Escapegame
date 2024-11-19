using UnityEngine;

public class GameController : MonoBehaviour
{
    public AchievementUI achievementUI;

    void Update()
    {
        // 스페이스바를 눌렀을 때 업적 UI 호출
        if (Input.GetKeyDown(KeyCode.Space))
        {
            achievementUI.ShowAchievementUI("첫 번째 업적 달성!");
        }
    }
}