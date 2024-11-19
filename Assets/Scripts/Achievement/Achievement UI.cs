using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public Animator achievementAnimator;
    public float displayDuration = 2.0f;
    

    // 업적 UI 표시
    public void ShowAchievementUI(string achievementName)
    {
        // 애니메이션 트리거 실행
        achievementAnimator.SetTrigger("Show");

        // 일정 시간 후 UI 숨김 애니메이션 실행
        Invoke("HideAchievementUI", displayDuration);
    }

    // 업적 UI 숨김
    private void HideAchievementUI()
    {
        achievementAnimator.SetTrigger("Hide");
    }




}
