using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
       
    }
    
    public SoundManager soundManager { get; private set; }
    public UIManager uiManager { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
        }
        
        soundManager = GetComponent<SoundManager>(); //find로 할지 고민하는중
        uiManager = GetComponent<UIManager>();
    }
    
    
}
