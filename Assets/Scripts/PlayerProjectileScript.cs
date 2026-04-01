using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    int damage;
    float projectileTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        projectileTime -= Time.deltaTime;
        if(projectileTime < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetUpProjectile(int newDmg, float projTime, string type = "basic")
    {
        damage = newDmg;
        projectileTime = projTime;

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // If colliding with wall, destroy self
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Throwable"))
        {
            collision.GetComponentInParent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
