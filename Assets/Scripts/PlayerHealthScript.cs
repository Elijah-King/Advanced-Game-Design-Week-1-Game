using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;


    public EnemyAI enemyai;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    
    
    
    
    
    
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Throwable"))
        {
            TakeDamage(25);
            StartCoroutine(enemyai.EnemyRecoil());
        }
    }








    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }







}
