using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] int kitHealthAmount = 3;


    protected override void OnHealthPickup(PlayerHealth playerHealth)
    {
        playerHealth.AddHealth(kitHealthAmount); // Add health to the player
    }
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        // No weapon or ammo pickup logic for health pickups
    }
}
