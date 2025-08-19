using UnityEngine;

public class InfernoBall : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] GameObject InfernoBallHitVFX;

    Rigidbody rb;

    int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.linearVelocity = transform.forward * speed; // Set the ball's velocity to move forward
    }

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage); // Damage the player if they are hit

        Instantiate(InfernoBallHitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destroy the inferno ball after hitting something
    }
}
