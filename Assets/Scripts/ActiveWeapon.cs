using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot = 0f;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShooting();
    }

    void HandleShooting()
    {
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shooting(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        starterAssetsInputs.ShootInput(false); // Reset shoot input after processing

    }
}