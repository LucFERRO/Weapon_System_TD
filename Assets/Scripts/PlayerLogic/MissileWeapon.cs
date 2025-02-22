using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileWeapon : Weapon
{
    public GameObject projectile;
    private bool isTargeting;
    //public int projectileSpeed;
    //public int rotateSpeed;
    //public float maxDistancePredict = 100;
    //public float minDistancePredict = 5;
    //public float maxTimePrediction = 5;
    //public float deviationAmount = 50;
    //public float deviationSpeed = 2;
    //public GameObject[] targets;
    public List<GameObject> targetObjects = new List<GameObject>();
    //public bool IsTargeting
    //{
    //    get
    //    {
    //        return isTargeting;
    //    }
    //    set
    //    {
    //        isTargeting = value;
    //    }
    //}
    public override void Start()
    {
        //currentCooldown = shootingCooldown;
    }
    public override void Shoot()
    {
        if (currentCooldown != 0)
        {
            return;
        }
        AcquiringTargets();
    }

    private void AcquiringTargets()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(shootingPoint.position, shootingPoint.forward, 40f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (!targetObjects.Contains(hit.collider.gameObject))
            {
                targetObjects.Add(hit.collider.gameObject);
                //Debug.Log($"added new target. New target count {targetObjects.Count}");
            }
        }
    }

    private void LaunchMissiles()
    {
        for (int i = 0; i < targetObjects.Count; i++)
        {
            GameObject spawnedProjectile = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
            MissileProjectileProperties spawnedProperties = spawnedProjectile.GetComponent<MissileProjectileProperties>();
            //spawnedProjectile.GetComponent<MissileProjectileProperties>.InitMissileProperties();
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().speed = projectileSpeed;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().maxDistancePredict = maxDistancePredict;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().minDistancePredict = minDistancePredict;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().maxTimePrediction = maxTimePrediction;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().deviationAmount = deviationAmount;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().deviationSpeed = deviationSpeed;
            //spawnedProjectile.GetComponent<MissileProjectileProperties>().rotateSpeed = rotateSpeed;
            spawnedProperties.damage = weaponDamage;
            spawnedProperties.targetGO = targetObjects[i];
        }
    }

    public override void Disengage()
    {
        if (targetObjects.Count == 0)
        {
            return;
        }
        LaunchMissiles();
        targetObjects.Clear();
        currentCooldown = shootingCooldown;
    }
}
