using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField]
    private AchievementUI achievementUI;
    // ������ ��ųʸ��� ����
    private Dictionary<EAchievementCode, List<Achievement>> achievements = new Dictionary<EAchievementCode, List<Achievement>>();
    
    // ������ �޼� �Ǳ� ���� �߰� ����
    public void IncreseAchievement(EAchievementCode code)
    {

        if (achievements.ContainsKey(code))
        {
            List<Achievement> list = achievements[code];

            foreach (Achievement achievement in list) 
            {
                if (!achievement.isCompleted) 
                {
                    achievement.IncrementProgress();

                    if (achievement.IsComplete())
                    {
                        achievement.isCompleted = true; // �Ϸ� ���� ������Ʈ
                        ShowAchievementUI(achievement);
                    }
                }
            }
        }
    }

    public void AddAchievement(Achievement achievement)
    {
        if (!achievements.ContainsKey(achievement.code)) 
        {
            achievements[achievement.code] = new List<Achievement>();
        }
        achievements[achievement.code].Add(achievement);
        Debug.Log($"���� '{achievement.name}'��(��) '{achievement.code}' �ڵ忡 �߰��Ǿ����ϴ�.");

    }

    public void InitializeAchievements()
    {
        // ��ųʸ��� �߰�
        AddAchievement(new Achievement( "4���� ��� ����", 4, 0, EAchievementCode.PassSuccess, "Sprites/Lucky"));
        //AddAchievement(new Achievement("�� Ŭ����!", 6, 0, EAchievementCode.PassSuccess, "Sprites/Exit"));
        //AddAchievement(new Achievement("3���� ��� ����", 3, 0, EAchievementCode.PassFail, "Sprites/Exitfail"));
        //AddAchievement(new Achievement("Ÿ�Ӿ��� �����Դϴ�.", 0, 15, EAchievementCode.TimeAttack, "Sprites/Time"));
        //AddAchievement(new Achievement("������� ����ǰ� Ŭ���� �Ǹ� ���� �����Դϴ�.", 1, 0, EAchievementCode.AudioClip, "Sprites/Manager"));
        //AddAchievement(new Achievement("���� ���� �����Դϴ�.", 1, 0, EAchievementCode.Lighting, "Sprites/Light"));
        AddAchievement(new Achievement("���� �� �ڵ带 �Ϻ��� �����߳�?", 1, 0, EAchievementCode.PassSuccess, "Sprites/Light"));
        AddAchievement(new Achievement("���ѰŸ� ��¼��", 3, 0, EAchievementCode.PassSuccess, "Sprites/Lucky"));
        AddAchievement(new Achievement("�ڵ�¥�°� ���� �����", 6, 0, EAchievementCode.PassSuccess, "Sprites/Exit"));

    }


    public void ShowAchievementUI(Achievement achievement)
    {
        achievementUI.ShowAchievementUI(achievement, achievement.imagePath);
    }

    // ����Ƽ���� ������ �� ȣ��
    void Start()
    {
        InitializeAchievements(); // ���� �ʱ�ȭ
    }

    void Update()
    {
        // ���� 1 Ű�� ������ �� curvalue ����
        if (Input.GetKeyDown(KeyCode.Space))// ���� 1 Ű
        {
            IncreseAchievement(EAchievementCode.PassSuccess); // PassSuccess ���� ����
        }
    }
}



//if (achievements.TryGetValue(code, out Achievement achievement))
//{
//    achievement.value++;
//}

// 1. ��ųʸ��� ���� �����͸� �߰��Ѵ�. 2. �̹� �ߴ� ������ �� �̻� �ȳ����� �ؾ��Ѵ�.
// �״����� UI�� ���� �Ϻ�������.
