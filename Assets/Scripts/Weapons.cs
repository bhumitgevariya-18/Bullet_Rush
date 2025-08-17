using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    Animator animator;
    const string SHOOT_STRING = "Shoot";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Shooting(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f); // Play the shooting animation

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity); // hitting vfx
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}