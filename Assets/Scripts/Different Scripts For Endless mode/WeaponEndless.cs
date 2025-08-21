using Cinemachine;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponEndless : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers; // Layer mask to specify which layers the raycast should interact with ex. not with base weapon pickup

    CinemachineImpulseSource impulseSource; // For camera shake effect 

    Animator animator;
    AudioSource audioSource;

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shooting(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        impulseSource.GenerateImpulse(); // Generate camera shake effect
        animator.Play(SHOOT_STRING, 0, 0f); // Play the shooting animation

        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        //QueryTriggerInteraction.Ignore is built in in unity to avoid all triggers in scene

        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity); // hitting vfx
            EnemyHealthEndless enemyHealthEndless = hit.collider.GetComponentInParent<EnemyHealthEndless>();
            //it was just GetComponent<EnemyHealth>() but it son't work with tower since it has 2 colliders in child and script on parent
            //also it is better to use GetComponentInParent since it starts checking from gameobject itself and then goes up the parent hierarchy

            enemyHealthEndless?.TakeDamage(weaponSO.Damage);
        }
    }
}