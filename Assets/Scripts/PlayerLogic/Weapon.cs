using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float weaponDamage;
    public Transform shootingPoint;
    public float shootingCooldown;
    public float currentCooldown;
    void Start()
    {
        currentCooldown = shootingCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            currentCooldown = 0;
        }
    }

    public virtual void Shoot()
    {

    }
}
