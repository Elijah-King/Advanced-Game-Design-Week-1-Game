using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables for movment 

    [SerializeField] float moveSpeed = 5.0f;

    [SerializeField] float acceleration = 10.0f;

    [SerializeField] float decceleration = 8f;

    [SerializeField] float velPower = 1.2f;


    public Rigidbody2D rb;


    // ------------------------------------------------------------------------------

    // variables for boundry

    public float pushBackForce = 0.1f;



 




    Vector2 moveInput;



 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    void Update()
    {
       
      
        

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Desired movement direction
        Vector2 targetVelocity = moveInput * moveSpeed;

        // Smooth acceleration toward target velocity
        Vector2 velocityDiff = targetVelocity - rb.linearVelocity;

        float accelRate = (targetVelocity.magnitude > 0.01f) ? acceleration : decceleration;

        Vector2 movement = velocityDiff * accelRate;

        rb.AddForce(movement);
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundry"))
        {
            Vector2 direction = (Vector2)transform.position - collision.ClosestPoint(transform.position).normalized;
            transform.position += (Vector3)(direction * pushBackForce);
        }
    }






    public void PlayerAttack(InputAction.CallbackContext ctx)
    {
        
    }


    public void GiveDamage()
    {

      
    }


}


