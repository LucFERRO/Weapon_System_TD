using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon currentWeapon;
    public int currentWeaponIndex;
    public int CurrentWeaponIndex
    {
        get
        {
            return currentWeaponIndex;
        }
        set
        {
            if (value > weapons.Length - 1)
            {
                value = 0;
            }
            else if (value < 0)
            {
                value = weapons.Length - 1;
            }

            currentWeaponIndex = value;
        }
    }
    void Start()
    {
        CurrentWeaponIndex = 0;
        currentWeapon = weapons[currentWeaponIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            CurrentWeaponIndex += 1;
            SwitchWeapon(currentWeaponIndex);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            CurrentWeaponIndex -= 1;
            SwitchWeapon(currentWeaponIndex);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        CurrentWeaponIndex = weaponIndex;
        currentWeapon = weapons[currentWeaponIndex];
    }
}
