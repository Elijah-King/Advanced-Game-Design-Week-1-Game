using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int maxHealth;
    public int currentHealth;

    [Header("Object References")]
    public Image healthBar;
    [SerializeField] TopEnemyThrower enemyThrowScript;


    [Header("DEBUG")] // Debug functions, triggered by activating the bool in the editor
    [SerializeField] bool d_TakeDamage = false;
    [SerializeField] bool d_ToasterBath = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        RunDebug(); // Run the debug checks
    }

    // Take Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }
    // Enemy dying script
    public void EnemyDeath()
    {
        Debug.Log("Enemy Death");
        // Disable enemy throw script if applicable
        if (enemyThrowScript != null)
        {
            enemyThrowScript.StopAllCoroutines();
            enemyThrowScript.enabled = false;
        }
    }

    // DEBUG FEATURES
    void RunDebug()
    {
        if (d_TakeDamage)
        {
            // Take a tenth of max health as damage
            TakeDamage(maxHealth / 10);
            d_TakeDamage = false;
        }
        if (d_ToasterBath)
        {
            // Instant death
            TakeDamage(maxHealth);
            d_ToasterBath = false;
        }
    }
}
