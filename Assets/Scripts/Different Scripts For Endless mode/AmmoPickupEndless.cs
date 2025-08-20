using UnityEngine;

public class AmmoPickupEndless : PickupEndless
{
    [SerializeField] int ammoAmount = 100; // Amount of ammo to add when picked up, biz size so it can fill any magazine

    protected override void OnPickup(ActiveWeaponEndless activeWeaponEndless)
    {
        activeWeaponEndless.ManageAmmo(ammoAmount); // Add ammo to the active weapon
    }

    protected override void OnHealthPickup(PlayerHealth playerHealth)
    {
        // No health pickup logic for ammo pickups
    }
}
