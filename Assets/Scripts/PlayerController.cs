using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables for movment 

    [SerializeField] float moveSpeed = 5.0f;

    [SerializeField] float acceleration = 10.0f;

    [SerializeField] float decceleration = 8f;

    [SerializeField] float velPower = 1.2f;

    [SerializeField] float jumpSpeed = 5f;

    [SerializeField] float gravityMultiplier = 2f;

    public Rigidbody2D rb;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask PlayerGroundLayer;
    SpriteRenderer spriteRenderer;

    bool isGrounded;





 




    Vector2 moveInput;



 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    void Update()
    {
       
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                PlayerGroundLayer
            );
        

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        float targetSpeed = moveInput.x * moveSpeed;

        float speedDif = targetSpeed - rb.linearVelocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);

        if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Vector2.down * gravityMultiplier, ForceMode2D.Force);
        }

  
    }

    public void PlayerJump(InputAction.CallbackContext ctx)
    {
       

        if (ctx.performed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            
        }
    }

    public void PlayerAttack(InputAction.CallbackContext ctx)
    {
        
    }


    public void GiveDamage()
    {

      
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

    }
}


