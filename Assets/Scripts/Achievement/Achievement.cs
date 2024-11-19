
public enum EAchievementCode
{
    PassSuccess,  // 통과 성공  1
    PassFail,     // 통과 실패  2
    TimeAttack,   // 타임 어택  3   
    AudioClip,    // 오디오 클립과 관련된 업적 4
    Lighting      // 조명과 관련된 업적 5
}

public class Achievement 
{
    public string name;
    public int value; // 업적 값
    public int curvalue = 0; // 현재 업적 값
    public float count; // 시간값
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

