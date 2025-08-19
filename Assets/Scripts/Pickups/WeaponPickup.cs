using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
    protected override void OnHealthPickup(PlayerHealth playerHealth)
    {
        // No health pickup logic for weapon pickups
    }
}
