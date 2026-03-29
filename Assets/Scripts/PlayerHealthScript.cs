using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    [Header("Player Stats")]
    public int maxHealth, currentHealth;

    [Header("Object References")]
    public Image healthBar;
    
    //public EnemyAI enemyai;
    //public float healthAmount = 100f;



    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        // If colliding with thrown enemy
        if (other.CompareTag("Throwable"))
        {
            // Player takes damage, enemy is knocked back
            TakeDamage(25);
            StartCoroutine(other.GetComponent<EnemyAI>().EnemyRecoil()); // This code feels off, maybe recoil should be changed later
        }
    }








    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
    }








}
