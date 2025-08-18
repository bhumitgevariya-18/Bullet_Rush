using UnityEngine;
using StarterAssets;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera; // Reference to the Cinemachine virtual camera
    [SerializeField] GameObject zoomScreen; // Reference to the zoom screen

    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    float timeSinceLastShot = 0f;
    float defaultFOV;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView; // Store the default FOV from the Cinemachine camera
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        HandleShooting();
        HandleZoming();
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
        timeSinceLastShot += Time.deltaTime;

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

    void HandleZoming()
    {
        if(!weaponSO.IsZoomable) return;

        if(starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomFOV; // Set the FOV to the zoomed value
            zoomScreen.SetActive(true); // Activate the zoom screen
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV; // Reset to the default FOV
            zoomScreen.SetActive(false); // Deactivate the zoom screen
        }

    }
}