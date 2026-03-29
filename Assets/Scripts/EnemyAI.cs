using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    // --------------------------------------------------------------------- EnemyGroundCheck variables

  

    [SerializeField] Transform EnemyGroundCheck;
    [SerializeField] float EnemyGroundCheckRadius = 0.2f;
    [SerializeField] LayerMask EnemyGroundLayer;

     bool isGrounded;


    //--------------------------------------------------------------------- EnemyAgro Logic variables

    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;


    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float forwardJumpSpeed = 2f;

    [SerializeField] float jumpDelay = 2f;

    float jumpTimer;



    [SerializeField] float enemyKnockbackForce = 6f;
    [SerializeField] float enemyKnockbackUpward = 2f;
    [SerializeField] float enemyHitRecoveryTime = 0.3f;

    bool isRecoiling = false;






    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpTimer = jumpDelay;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
             EnemyGroundCheck.position,
             EnemyGroundCheckRadius,
             EnemyGroundLayer
         );


        if (isGrounded && !isRecoiling)
        {
            Debug.Log("Enemy is touching ground");

            jumpTimer -= Time.deltaTime;

            if(jumpTimer <= 0f)
            {
                enemyJump();
                jumpTimer = jumpDelay;
            }
        
        }





        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
         if(distToPlayer < agroRange)
        {
          
        }
    
    
    
    }



    void enemyJump()
    {
        // Use the same left/right logic as ChasePlayer()
        float direction = transform.position.x < player.position.x ? 1f : -1f;

        // Combine forward + upward force
        Vector2 jumpForce = new Vector2(direction * forwardJumpSpeed, jumpSpeed);

        rb2d.AddForce(jumpForce, ForceMode2D.Impulse);

        Debug.Log("Enemy jumped toward the player!");
    }





    void OnDrawGizmosSelected()
    {
        if (EnemyGroundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(EnemyGroundCheck.position, EnemyGroundCheckRadius);
        }

    }






    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
           // enemy is on left side, so move right
            rb2d.linearVelocity = new Vector2(moveSpeed, 0);

        }
        else 
        {
           
            // enemy is on right side, so move left
            rb2d.linearVelocity = new Vector2(-moveSpeed, 0);
        }
    
    
    
    
    
    }


    public void TakeRecoil()
    {
        StartCoroutine(EnemyRecoil());
    }

  public  IEnumerator EnemyRecoil()
    {
        isRecoiling = true;

        // Determine direction AWAY from the player
        float direction = transform.position.x < player.position.x ? -1f : 1f;

        // Apply knockback to the enemy
        Vector2 force = new Vector2(direction * enemyKnockbackForce, enemyKnockbackUpward);
        rb2d.AddForce(force, ForceMode2D.Impulse);

        // Wait a moment before enemy can act again
        yield return new WaitForSeconds(enemyHitRecoveryTime);

        isRecoiling = false;
    }








}
