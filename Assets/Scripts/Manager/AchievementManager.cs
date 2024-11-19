using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    // ������ ��ųʸ��� ����
    private Dictionary<EAchievementCode, List<Achievement>> achievements = new Dictionary<EAchievementCode, List<Achievement>>();
    
    public void IncreseAchievement(EAchievementCode code)
    {

        if (achievements.ContainsKey(code))
        {
            List<Achievement> list = achievements[code];

            foreach (Achievement achievement in list) 
            {
                achievement.curvalue++;
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
        // ���� 1 ����
        Achievement achievement1 = new Achievement
        {
            name = "3���� ��� ����",
            value = 3,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.PassSuccess
        };

        // ���� 2 ����
        Achievement achievement2 = new Achievement
        {
            name = "�� Ŭ����, ��� ����",
            value = 6,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.PassSuccess
        };

        // ���� 3 ����
        Achievement achievement3 = new Achievement
        {
            name = "���� ���� �����Դϴ�.",
            value = 1,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.Lighting
        };


        // ��ųʸ��� �߰�
        AddAchievement(achievement1);
        AddAchievement(achievement2);
        AddAchievement(achievement3);
    }

    public void ShowAchievementUI()
    {

    }

    public void PrintAllAchievements()
    {
        foreach (var pair in achievements)
        {
            Debug.Log($"���� �ڵ�: {pair.Key}, ���� ����: {pair.Value.Count}");
            foreach (Achievement achievement in pair.Value)
            {
                //Debug.Log($" - {achievement.name}: {achievement.curvalue}/{achievement.value}");
            }
        }
    }

    // ����Ƽ���� ������ �� ȣ��
    void Start()
    {
        InitializeAchievements(); // ���� �ʱ�ȭ
        PrintAllAchievements(); // ����׿� ������ ���
    }
}



//if (achievements.TryGetValue(code, out Achievement achievement))
//{
//    achievement.value++;
//}

// 1. ��ųʸ��� ���� �����͸� �߰��Ѵ�. 2. �̹� �ߴ� ������ �� �̻� �ȳ����� �ؾ��Ѵ�.
// �״����� UI�� ���� �Ϻ�������.
