using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        //Vector3 direction
    }
}
