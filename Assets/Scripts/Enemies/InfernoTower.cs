using System.Collections;
using UnityEngine;

public class InfernoTower : MonoBehaviour
{
    [SerializeField] GameObject infernoBallPrefab;
    [SerializeField] Transform towerHead; // The part of the tower that rotates and shoots
    [SerializeField] Transform TargetPlayer;
    [SerializeField] Transform infernoBallSpawnPoint;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireInfernoBall());
    }

    private void Update()
    {
        towerHead.LookAt(TargetPlayer); // Make the tower head look at the camera
    }

    IEnumerator FireInfernoBall()
    {
        while(playerHealth)
        {
            yield return new WaitForSeconds(fireRate);
            InfernoBall newInfernoBall = Instantiate(infernoBallPrefab, infernoBallSpawnPoint.position, Quaternion.identity).GetComponent<InfernoBall>();
            newInfernoBall.transform.LookAt(TargetPlayer); // Make the inferno ball look at the player , did this bcz the shot was going above player so this will eliminate that difference of pivot position
            newInfernoBall.Initialize(damage); // Initialize the inferno ball with damage
        }
    }
}
