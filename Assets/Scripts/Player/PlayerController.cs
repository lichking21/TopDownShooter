using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Inventory inv;

    private bool isShooting;
    public Weapon currWeapon;
    public GameObject holdPoint_AR;

    [SerializeField] private float speed;
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

    public void StartShoot()
    {
        isShooting = true;
    }
        
    public void StopShoot()
    {
        isShooting = false;
    }

    void Update()
    {
        // Movement
        rb.velocity = moveInput * speed;
        anim.SetFloat("Speed", moveInput.magnitude);

        //Shooting
        if (isShooting)
        {
            currWeapon.Shoot();
        }
        anim.SetBool("Shoot", isShooting);
    }
}
