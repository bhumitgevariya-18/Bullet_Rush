using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    float timeSinceLastShot = 0f;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
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

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject); // Destroy the current weapon to switch into new weapon
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }

    void HandleShooting()
    {
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shooting(weaponSO);
            timeSinceLastShot = 0f;
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false); // Reset shoot input after processing
        }
    }
}