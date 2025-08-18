using System.Collections;
using UnityEngine;

public class InfernoTower : MonoBehaviour
{
    [SerializeField] GameObject infernoBallPrefab;
    [SerializeField] Transform towerHead; // The part of the tower that rotates and shoots
    [SerializeField] Transform TargetPlayer;
    [SerializeField] Transform infernoBallSpawnPoint;
    [SerializeField] float fireRate = 2f;

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
            Instantiate(infernoBallPrefab, infernoBallSpawnPoint.position, towerHead.rotation);
        }
    }
}
