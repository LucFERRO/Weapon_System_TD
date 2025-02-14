using UnityEngine;

public class Beam : Weapon
{
    public LineRenderer laserBeam;
    public override void Shoot()
    {
        //GameObject spawnedProjectile = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        //spawnedProjectile.GetComponent<Rigidbody>().linearVelocity = transform.forward * projectileSpeed;
        //currentCooldown = shootingCooldown;
        Physics.RaycastAll(shootingPoint.position, shootingPoint.forward, 100);

    }
    private void OnDrawGizmos()
    {
        //Giz
    }
}