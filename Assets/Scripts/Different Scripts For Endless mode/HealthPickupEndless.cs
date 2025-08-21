using UnityEngine;

public class HealthPickupEndless : PickupEndless
{
    [SerializeField] int kitHealthAmount = 5;

    protected override void OnHealthPickup(PlayerHealth playerHealth)
    {
        playerHealth.AddHealth(kitHealthAmount); // Add health to the player
    }

    protected override void OnPickup(ActiveWeaponEndless activeWeaponEndless)
    {
        // Nothing happens here for health pickups
    }
}
