using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHp;
    public float currentHp;
    public KillCountScript killCountScript;
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        if (currentHp <= damage) {
            killCountScript.KillCount += 1;
            Destroy(gameObject);
        } else
        {
            currentHp -= damage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            int incomingDamage = other.GetComponent<LaserProjectileProperties>() ? other.GetComponent<LaserProjectileProperties>().damage : other.GetComponent<MissileProjectileProperties>().damage;
            Destroy(other.gameObject);
            TakeDamage(incomingDamage);
        }
    }
}
