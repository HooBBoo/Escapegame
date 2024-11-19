using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public Animator achievementAnimator;
    public TextMeshProUGUI achievementText;
    public Image achievementImage; // ���� �̹����� ǥ���� UI
    public float displayDuration = 2.0f;
    

    // ���� UI ǥ��
    public void ShowAchievementUI(Achievement achievement, string imagePath)
    {

        // ���� �̸��� �̹��� ����
        achievementText.text = $"{achievement.name}";
        //achievementImage.sprite = image; //�̹��� ���
        Sprite sprite = Resources.Load<Sprite>(imagePath);
        if (sprite != null)
        {
            achievementImage.sprite = sprite; // UI�� �̹��� ����
        }

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
