using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField, Tooltip("Debug value")] private Vector2 _Input;
    public Rigidbody2D _Rigidbody2D { get; private set; }
    public bool UseMotor = true;

    public static PlayerMovement instance { get; private set; }
    private void Awake() => instance = this;
    private void Start() => Init();
    private void Init()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void UpdateInput()
    {
        _Input = new Vector2
            (
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
    }
    private void UpdateMotor()
    {
        if (!UseMotor)
        {
            _Rigidbody2D.velocity = Vector2.zero;
            return;
        }

        _Rigidbody2D.velocity = _Input * Speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Door>(out Door door))
        {
            door.Tp();
        }
    }

    private void Update()
    {
        UpdateInput();
    }
    private void FixedUpdate()
    {
        UpdateMotor();
    }
}
