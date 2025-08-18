using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 100; // Amount of ammo to add when picked up, biz size so it can fill any magazine

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.ManageAmmo(ammoAmount); // Add ammo to the active weapon
    }
}
