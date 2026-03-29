using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    [Header("Player Stats")]
    public int maxHealth, currentHealth;
    float playerInvulnTime = 1f, currentInvulnTime;


    [Header("Object References")]
    public Image healthBar;
    
    public EnemyAI enemyai;
    //public float healthAmount = 100f;



    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInvulnTime > 0f)
        {
            currentInvulnTime -= Time.deltaTime;
        }
    
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        // If colliding with thrown enemy
        if (other.CompareTag("Throwable") && currentInvulnTime <= 0f)
        {
            // Player takes damage, enemy is knocked back
            TakeDamage(25);
            other.GetComponentInParent<EnemyAI>().TakeRecoil();
            // This code feels off, maybe recoil should be changed later
            currentInvulnTime = playerInvulnTime;
        }
    }








    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Change health bar fill (float is used since integer division does not work
        healthBar.fillAmount = (float) currentHealth / maxHealth;
    }








}
