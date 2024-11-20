using UnityEngine;

public interface IChildAction //기능을 실행시켜주기 위한 작업
{
    void ExecuteRandomAction();
}
public class Object : MonoBehaviour, IChildAction
{
    // 인터페이스를 구현했지만 실제로 기능은 구체적인 자식 클래스들이 정의
    public virtual void ExecuteRandomAction()
    {
        
    }
}
