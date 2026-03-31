using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] string weaponType;
    [Header("Base Weapon Stats")]
    [SerializeField] int baseDamage;
    [SerializeField] float baseAttackCooldown;

    // True weapon stats
    int damage;
    float attackCooldownAmount;
    float attackCooldownTime;

    [SerializeField] GameObject projPrefab;
    [SerializeField] GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackCooldownTime = baseAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldownTime -= Time.deltaTime;
        FireWeapon(GetMousePosition());
    }
    public bool FireWeapon(Vector2 mousePos)
    {
        //Debug.Log(Vector2.Angle(transform.position, mousePos));
        //Debug.Log(new Vector2(Player.transform.position.x, Player.transform.position.y));
        // return false if weapon can't fire yet
        if (attackCooldownTime > 0)
        {
            return false;
        }
        // Otherwise, continue
        Debug.Log("ATTACK PASSED");
        
        attackCooldownTime = baseAttackCooldown;

        // For now, use the weapon position for firing position
        Vector2 startPos = new(Player.transform.position.x, Player.transform.position.y);
        //startPos = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        //// Get the angle between the start position and the mouse position given
        ////float shotAngle = Vector2.SignedAngle(startPos, mousePos);
        //float shotAngle = Vector2.SignedAngle(Vector2.zero, mousePos - startPos);

        //// Convert to radians?
        //shotAngle = shotAngle * 180f / Mathf.PI;

        GameObject newProjectile = Instantiate(projPrefab, transform);
        Vector2 shotVelocity;

        //shotVelocity = new Vector2(Mathf.Cos(shotAngle), Mathf.Sin(shotAngle));
        //shotVelocity = Vector2.Lerp(startPos, mousePos, 1f);
        shotVelocity = mousePos - startPos;

        shotVelocity = shotVelocity.normalized;
        //shotVelocity = shotVelocity.normalized * 20f;

        newProjectile.GetComponent<Rigidbody2D>().AddForce(shotVelocity * 10f, ForceMode2D.Impulse);



        // Return that weapon successfully fired
        return true;
    }

    public void CalculateWeaponStats(int upgradePoints)
    {

    }
    public void CalculateWeaponStats(int dmgMult, float cooldownMult)
    {

    }


    public Vector2 GetMousePosition()
    {
        //Vector3 mousePosV3 = Input.mousePosition;
        ////mousePosV3.z = Camera.main.nearClipPlane;
        //mousePosV3.z = 0f;
        //Vector3 mousePositionV3 = Camera.main.ScreenToWorldPoint(mousePosV3);
        //// Convert mouse position to Vector2
        //Vector2 mousePosV2 = new(mousePositionV3.x, mousePositionV3.y);


        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosV2 = new(worldPosition.x, worldPosition.y);
        return mousePosV2;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GetMousePosition(), 1f);
        Debug.Log(GetMousePosition());
    }
}
