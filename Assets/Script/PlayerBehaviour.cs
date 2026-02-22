using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : Player
{
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
