
using System.Diagnostics;

public enum EAchievementCode
{
    PassSuccess,  // ��� ����  1
    PassFail,     // ��� ����  2
    TimeAttack,   // Ÿ�� ����  3   
    AudioClip,    // ����� Ŭ���� ���õ� ���� 4
    Lighting      // ����� ���õ� ���� 5
}

public class Achievement 
{
    public string imagePath; // �̹��� ���
    public string name; // ȭ�鿡 ����� �̸�
    public int value; // ���� ��
    public int curvalue = 0; // ���� ���� ��
    public float count; // �ð���
    public EAchievementCode code; // �ڵ�
    public bool isCompleted; // �Ϸ� ���� �÷���



    public bool IsComplete()
    {
        if ( curvalue >= value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncrementProgress()
    {
        if (!IsComplete())
        {
            curvalue++;
        }
    }

    public Achievement(string name, int value, float count, EAchievementCode code, string imagePath)
    {
        this.imagePath = imagePath;
        this.name = name;
        this.value = value;
        this.count = count;
        this.code = code;
        this.isCompleted = false; // ó���� �Ϸ���� ����
    }
}

