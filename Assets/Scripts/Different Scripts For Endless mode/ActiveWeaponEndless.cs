using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;

public class ActiveWeaponEndless : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeapon;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera; // Reference to the Cinemachine virtual camera
    [SerializeField] GameObject zoomScreen; // Reference to the zoom screen
    [SerializeField] TMP_Text ammoText; // Reference to the ammo text UI

    WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    WeaponEndless currentWeapon;

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView; // Store the default FOV from the Cinemachine camera
        defaultRotationSpeed = firstPersonController.RotationSpeed; // Store the default rotation speed
    }

    void Start()
    {
        SwitchWeapon(startingWeapon); // Switch to the starting weapon at the beginning
        ManageAmmo(currentWeaponSO.MagazineSize); // Initialize ammo with the maximum ammo of the starting weapon
    }

    void Update()
    {
        HandleShooting();
        HandleZoming();
    }

    public void ManageAmmo(int amount)
    {
        currentAmmo += amount; // Increase ammo based on the amount

        if (currentAmmo > currentWeaponSO.MagazineSize)
        {
            currentAmmo = currentWeaponSO.MagazineSize; // Ensure ammo doesn't exceed magazine size
        }

        ammoText.text = currentAmmo.ToString("D2"); // Update the ammo text UI, D2 formats the number to always show two digits
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject); // Destroy the current weapon to switch into new weapon
        }

        WeaponEndless newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<WeaponEndless>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        ManageAmmo(currentWeaponSO.MagazineSize); // Initialize ammo with the maximum ammo of the new weapon
    }

    void HandleShooting()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shooting(currentWeaponSO);
            timeSinceLastShot = 0f;
            ManageAmmo(-1); // Decrease ammo by 1 when shooting
        }

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false); // Reset shoot input after processing
        }
    }

    void HandleZoming()
    {
        if (!currentWeaponSO.IsZoomable) return;

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomFOV; // Set the FOV to the zoomed value
            zoomScreen.SetActive(true); // Activate the zoom screen
            currentWeapon.GetComponentInChildren<MeshRenderer>().enabled = false; // Hide the weapon mesh when zoomed
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.ZoomRotationSpeed); // Optionally reduce rotation speed when zoomed
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV; // Reset to the default FOV
            zoomScreen.SetActive(false); // Deactivate the zoom screen
            currentWeapon.GetComponentInChildren<MeshRenderer>().enabled = true; // Show the weapon mesh when not zoomed
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }

    }
}