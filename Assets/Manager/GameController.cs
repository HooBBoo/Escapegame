using UnityEngine;

public class GameController : MonoBehaviour
{
    public AchievementUI achievementUI;

    void Update()
    {
        // �����̽��ٸ� ������ �� ���� UI ȣ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            achievementUI.ShowAchievementUI("ù ��° ���� �޼�!");
        }
    }
}