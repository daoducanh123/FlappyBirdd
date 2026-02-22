using Unity.VisualScripting;
using UnityEngine.InputSystem;

using UnityEngine;

public class Player : MonoBehaviour
{
    // ================= Initialize ========================
    public static Player Instance;
    [SerializeField] protected Sprite[] sprites;

    
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;


    [SerializeField] protected float jumpForce = 15f;
    [SerializeField] protected float rotationSpeed = 2f;
    protected Vector2 jumpDirection = Vector2.up;

    
    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject); // nếu chỉ có 1 scene ko cần destroy on load

    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();

    }

     void Start()
    {
        InvokeRepeating(nameof(AnimationRepeat), 0.15f, 0.15f);
        
    }

    void Update()
    {
        CheckInput();   
    }

    void FixedUpdate()
    {
        Rotation();
    }

    // ================ Check Input =======================
    void CheckInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            Jump();
        }

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Jump();
        }
    }

    // ================= Animation =========================

    int idx = 0;
    private void AnimationRepeat()
    {
        if (idx >= sprites.Length) idx = 0;
        spriteRenderer.sprite = sprites[idx];
        idx++;
    }

    // ============== Jump && Rotation ===================
    private void Jump()
    {
        jumpDirection = Vector2.up * jumpForce;
        rb.linearVelocity = jumpDirection;
    }

    private void Rotation()
    {
        transform.rotation = Quaternion.Euler(0,0, rb.linearVelocity.y * rotationSpeed);
    }

}
