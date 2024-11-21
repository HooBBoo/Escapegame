using UnityEngine;

public class Enermy : Object
{
    private AudioSource audioSource;
    // AudioSource 컴포넌트 참조
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource 컴포넌트가 부착되지 않았습니다. 오디오 소스를 추가하세요.");
        }
    }
    private void Start()
    {
        InvokeRepeating("PlayRecordedSound", 0f, 3f);
        // 3초마다 재생
    }
    private void PlayRecordedSound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); Debug.Log("녹음된 소리가 재생되었습니다.");
        }
    }
    public override void ExecuteRandomAction()
    {
        int randomValue = Random.Range(0, 2); 
        bool shouldActivate = randomValue == 1;
        // 활성화 여부를 무작위로 결정

        gameObject.SetActive(shouldActivate);
        // 활성화 상태 설정

        hasChanged = !shouldActivate;
        // 변경됨을 표시

        if (shouldActivate)
        {
            Debug.Log($"{gameObject.name} 오브젝트가 활성화되었습니다.");
        }
        else
        {
            Debug.Log($"{gameObject.name} 오브젝트가 비활성화 상태를 유지합니다.");
        }
        // 활성화 또는 비활성화 상태 로그 출력
    }
}
