using UnityEngine;

public class WeaponPickupEndless : PickupEndless
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeaponEndless activeWeaponEndless)
    {
        activeWeaponEndless.SwitchWeapon(weaponSO);
    }
    protected override void OnHealthPickup(PlayerHealth playerHealth)
    {
        // No health pickup logic for weapon pickups
    }
}
