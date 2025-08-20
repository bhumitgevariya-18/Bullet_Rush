using UnityEngine;

public abstract class PickupEndless : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f; // Speed of rotation for the pickup item

    const string PLAYER_STRING = "Player";
    const string HEALTH_PICKUP_STRING = "HealthPickup";


    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); // Rotate the pickup item
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            if (this.CompareTag(HEALTH_PICKUP_STRING))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                OnHealthPickup(playerHealth);
                Destroy(this.gameObject); // Destroy the health pickup after it has been picked up

            }

            ActiveWeaponEndless activeWeaponEndless = other.GetComponentInChildren<ActiveWeaponEndless>();
            OnPickup(activeWeaponEndless);
            Destroy(this.gameObject); // Destroy the pickup after it has been picked up
        }
    }

    protected abstract void OnPickup(ActiveWeaponEndless activeWeaponEndless);

    protected abstract void OnHealthPickup(PlayerHealth playerHealth);
}
