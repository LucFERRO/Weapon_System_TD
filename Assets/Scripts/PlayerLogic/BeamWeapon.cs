using Unity.VisualScripting;
using UnityEngine;

public class BeamWeapon : Weapon
{
    public LineRenderer laserBeam;
    private bool isShooting;
    public bool IsShooting
    {
        get
        {
            return isShooting;
        }
        set
        {
            isShooting = value;
            laserBeam.enabled = value;
        }
    }

    public override void Start()
    {
        //transform.AddComponent<LineRenderer>();
        laserBeam = GetComponent<LineRenderer>();
        //shootPoint = transform.GetChild(1);
    }


    public override void Shoot()
    {
        laserBeam.SetPositions(new Vector3[] { shootingPoint.position, shootingPoint.position + shootingPoint.forward * 40f });
        IsShooting = true;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(shootingPoint.position, shootingPoint.forward, 40f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            HealthSystem healthSystem = hit.transform.GetComponent<HealthSystem>();
            if (healthSystem)
            {
                healthSystem.TakeDamage(weaponDamage);
            }
        }
    }

    public override void Disengage()
    {
        IsShooting = false;
    }

}