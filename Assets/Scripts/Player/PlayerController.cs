using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    public GameObject holdPoint_AR;

    private Rigidbody2D rb;
    private PlayerInputSystem input;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputSystem();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;
    }

    void OnDisable()
    {
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;
        input.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        rb.velocity = moveInput * speed;
        anim.SetFloat("Speed", moveInput.magnitude);
    }
}
