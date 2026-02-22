using Unity.VisualScripting;
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

}
