using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public Animator achievementAnimator;
    public float displayDuration = 2.0f;
    

    // ���� UI ǥ��
    public void ShowAchievementUI(string achievementName)
    {
        // �ִϸ��̼� Ʈ���� ����
        achievementAnimator.SetTrigger("Show");

        // ���� �ð� �� UI ���� �ִϸ��̼� ����
        Invoke("HideAchievementUI", displayDuration);
    }

    // ���� UI ����
    private void HideAchievementUI()
    {
        achievementAnimator.SetTrigger("Hide");
    }




}
