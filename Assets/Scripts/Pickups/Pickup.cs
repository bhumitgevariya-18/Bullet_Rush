using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f; // Speed of rotation for the pickup item

    const string PLAYER_STRING = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); // Rotate the pickup item
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject); // Destroy the pickup after it has been picked up
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
