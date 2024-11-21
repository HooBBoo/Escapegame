using UnityEngine;

public interface IChildAction //기능을 실행시켜주기 위한 작업
{
    void ExecuteRandomAction();
}
public class Object : MonoBehaviour, IChildAction
{
    protected bool hasChanged = false;
    private Quaternion originalRotation; // 초기 회전 상태 저장
    private Material originalMaterial; // 초기 머티리얼 저장
    public Renderer objectRenderer; // Renderer 참조
    private void Awake()
    {
        originalRotation = transform.rotation;
        objectRenderer = GetComponent<MeshRenderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    public bool HasChanged()
    {
        return hasChanged;
    }
    // 인터페이스를 구현했지만 실제로 기능은 구체적인 자식 클래스들이 정의
    public virtual void ExecuteRandomAction()
    {
        
    }
    
    public void ResetToOriginalState()
    {
        transform.rotation = originalRotation;
        if (objectRenderer != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }
}
