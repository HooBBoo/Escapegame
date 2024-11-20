using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Singleton<AchievementManager>
{
    [SerializeField]
    private AchievementUI achievementUI;
    // 업적을 딕셔너리로 관리
    private Dictionary<EAchievementCode, List<Achievement>> achievements = new Dictionary<EAchievementCode, List<Achievement>>();
    
    // 업적이 달성 되기 위한 추가 과정
    public void IncreseAchievement(EAchievementCode code, float time = 0)
    {

        if (achievements.ContainsKey(code))
        {
            List<Achievement> list = achievements[code];

            foreach (Achievement achievement in list) 
            {
                if (time != 0 && achievement.count >= time)
                {
                    continue;
                }
                if (code == EAchievementCode.PassFail) { ResetPassAchievement(); }
                if (!achievement.isCompleted) 
                {
                    achievement.IncrementProgress();

                    if (achievement.isCompleted)
                    {
                        ShowAchievementUI(achievement);
                    }
                }
            }
        }
    }

    public void ResetPassAchievement() 
    {
        if(!achievements.ContainsKey(EAchievementCode.PassSuccess))
        {
            return;
        }
        List<Achievement> list = achievements[EAchievementCode.PassSuccess];

        foreach (Achievement achievement in list)
        {
            achievement.curvalue = 0;
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
        // 딕셔너리에 추가
        AddAchievement(new Achievement("4연속 통과 성공", 4, 0, EAchievementCode.PassSuccess, "Sprites/Lucky"));
        AddAchievement(new Achievement("올 클리어!", 6, 0, EAchievementCode.PassSuccess, "Sprites/Exit"));
        AddAchievement(new Achievement("3연속 통과 실패", 3, 0, EAchievementCode.PassFail, "Sprites/Exitfail"));
        AddAchievement(new Achievement("타임어택 업적입니다.", 0, 15, EAchievementCode.TimeAttack, "Sprites/Time"));
        AddAchievement(new Achievement("오디오가 재생되고 클리어 되면 깨는 업적입니다.", 1, 0, EAchievementCode.AudioClip, "Sprites/Manager"));
        AddAchievement(new Achievement("조명 관련 업적입니다.", 1, 0, EAchievementCode.Lighting, "Sprites/Light"));
        //AddAchievement(new Achievement("나는 이 코드를 완벽히 이해했나?", 1, 0, EAchievementCode.PassSuccess, "Sprites/Light"));
        //AddAchievement(new Achievement("못한거면 어쩌지", 3, 0, EAchievementCode.PassSuccess, "Sprites/Lucky"));
        //AddAchievement(new Achievement("코드짜는게 제일 어려워", 6, 0, EAchievementCode.PassSuccess, "Sprites/Exit"));

    }


    public void ShowAchievementUI(Achievement achievement)
    {
        achievementUI.ShowAchievementUI(achievement, achievement.imagePath);
    }

    // 유니티에서 시작할 때 호출
    void Start()
    {
        InitializeAchievements(); // 업적 초기화
    }

    void Update()
    {
        // 숫자 1 키가 눌렸을 때 curvalue 증가
        if (Input.GetKeyDown(KeyCode.Space))// 숫자 1 키
        {
            IncreseAchievement(EAchievementCode.PassSuccess); // PassSuccess 업적 증가
        }
    }
}



//if (achievements.TryGetValue(code, out Achievement achievement))
//{
//    achievement.value++;
//}

// 1. 딕셔너리에 업적 데이터를 추가한다. 2. 이미 했던 업적은 더 이상 안나오게 해야한다.
// 그다음에 UI에 띄우면 완벽해진다.
