using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers; // Layer mask to specify which layers the raycast should interact with ex. not with base weapon pickup
    
    CinemachineImpulseSource impulseSource; // For camera shake effect 

    Animator animator;
    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>(); 
        animator = GetComponent<Animator>();
    }

    public void Shooting(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        impulseSource.GenerateImpulse(); // Generate camera shake effect
        animator.Play(SHOOT_STRING, 0, 0f); // Play the shooting animation

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        //QueryTriggerInteraction.Ignore is built in in unity to avoid all triggers in scene

        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity); // hitting vfx
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            //it was just GetComponent<EnemyHealth>() but it son't work with tower since it has 2 colliders in child and script on parent
            //also it is better to use GetComponentInParent since it starts checking from gameobject itself and then goes up the parent hierarchy

            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}