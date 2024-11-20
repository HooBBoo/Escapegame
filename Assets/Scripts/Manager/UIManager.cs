
//몇 홀 인지 나타내는 UI, 타이머 UI, 

using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI numberText; //몇 홀인지 알려주는 텍스트
    private float numberUp;
    
    [Header("Time")]
    private float elapsedTime; // 경과된 시간(초 단위)
    public TextMeshProUGUI timeText;

    private void Update()
    {
        elapsedTime += Time.deltaTime; // 매 프레임 경과된 시간 추가
        UITimeUpdate();
        
    }

    //숫자가 올라가는 로직 작성
    public void UINumberUpdate()
    {
        string floor = TriggerManager.Instance.currentfloor.ToString();
        numberText.text = floor;
    }
    
    //시간 분초 나타내기
    private void UITimeUpdate()
    {
        int minutes = (int)(elapsedTime / 60); //분
        int seconds = (int)(elapsedTime % 60); //초

        // 두 자리 수 형식으로 포맷
        timeText.text = $"{minutes:00}:{seconds:00}";
        
    }
}
