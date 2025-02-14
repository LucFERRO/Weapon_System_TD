using UnityEngine;

public class Laser : Weapon
{
    public GameObject projectile;
    public float projectileSpeed;
    public override void Shoot()
    {
        if (currentCooldown == 0)
        {

            GameObject spawnedProjectile = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
            spawnedProjectile.GetComponent<LaserProjectileProperties>().damage = weaponDamage;
            spawnedProjectile.GetComponent<Rigidbody>().linearVelocity = transform.forward * projectileSpeed;
            currentCooldown = shootingCooldown;
        }
    }
}