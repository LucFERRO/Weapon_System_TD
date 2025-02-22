using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int weaponDamage;
    public Transform shootingPoint;
    public float shootingCooldown;
    public float currentCooldown;
    public virtual void Start()
    {
        currentCooldown = 0;
    }

    // Update is called once per frame
    public virtual void Update()
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
    public virtual void Disengage()
    {

    }
}
