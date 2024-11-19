using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    // 업적을 딕셔너리로 관리
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
        Debug.Log($"업적 '{achievement.name}'이(가) '{achievement.code}' 코드에 추가되었습니다.");

    }

    public void InitializeAchievements()
    {
        // 업적 1 생성
        Achievement achievement1 = new Achievement
        {
            name = "3연속 통과 성공",
            value = 3,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.PassSuccess
        };

        // 업적 2 생성
        Achievement achievement2 = new Achievement
        {
            name = "올 클리어, 통과 성공",
            value = 6,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.PassSuccess
        };

        // 업적 3 생성
        Achievement achievement3 = new Achievement
        {
            name = "조명 관련 업적입니다.",
            value = 1,
            curvalue = 0,
            count = 0,
            code = EAchievementCode.Lighting
        };


        // 딕셔너리에 추가
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
            Debug.Log($"업적 코드: {pair.Key}, 업적 개수: {pair.Value.Count}");
            foreach (Achievement achievement in pair.Value)
            {
                //Debug.Log($" - {achievement.name}: {achievement.curvalue}/{achievement.value}");
            }
        }
    }

    // 유니티에서 시작할 때 호출
    void Start()
    {
        InitializeAchievements(); // 업적 초기화
        PrintAllAchievements(); // 디버그용 데이터 출력
    }
}



//if (achievements.TryGetValue(code, out Achievement achievement))
//{
//    achievement.value++;
//}

// 1. 딕셔너리에 업적 데이터를 추가한다. 2. 이미 했던 업적은 더 이상 안나오게 해야한다.
// 그다음에 UI에 띄우면 완벽해진다.
