
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
    public string name;
    public int value; // ���� ��
    public int curvalue = 0; // ���� ���� ��
    public float count; // �ð���
    public EAchievementCode code;


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


}

