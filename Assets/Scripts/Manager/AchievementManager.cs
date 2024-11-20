using System;
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
        if (achievements.ContainsKey(code)) //해당 업적이 딕셔너리에 있으면
        {
            List<Achievement> list = achievements[code]; // 그 딕셔너리를 List에 넣는다.

            foreach (Achievement achievement in list) // 해당 업적 리스트를 전체 순회하면서
            {
                if (time != 0 && achievement.count >= time) // 시간이 0 이 아니거나 시간이 오버된경우
                {
                    continue; // 업적UI 비활성
                }
                // 3연속 실패 하다가 성공 나왔을 때 초기화
                if (code == EAchievementCode.PassFail) { ResetPassSuccessAchievement(); } 
                // 4연속 성공하다가 실패 나왔을 때 초기화 
                if (code == EAchievementCode.PassSuccess) { ResetPassFailAchievement(); }

                if (!achievement.isCompleted) // 성공하지 않았다면
                {
                    achievement.IncrementProgress(); // curvalue ++

                    if (achievement.isCompleted) // 성공 시
                    {
                        ShowAchievementUI(achievement); // UI 띄우기
                    }
                }
            }
        }
    }

    private void ResetPassFailAchievement() //업적 초기화
    {
        // 업적이 없으면 return = 0 , 업적이 있으면 curvalue 0으로 만들기
        if (!achievements.ContainsKey(EAchievementCode.PassFail))
        {
            return;
        }
        // if문 밖이니 성공했단 뜻으로, 리스트에 넣어주고
        List<Achievement> list = achievements[EAchievementCode.PassFail];

        foreach (Achievement achievement in list) // 리스트를 순회하며
        {
            achievement.curvalue = 0;// 초기화
        }
    }

    public void ResetPassSuccessAchievement() 
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
    { //새로운 업적을 딕셔너리에 추가
        if (!achievements.ContainsKey(achievement.code)) //해당 코드가 있는 딕셔너리가 없다면
        {
            achievements[achievement.code] = new List<Achievement>(); //리스트에 새롭게 추가
        }
        achievements[achievement.code].Add(achievement); //해당 코드가 있는 리스트에 추가
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