using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class RobotEndless : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    GameManagerEndless gameManagerEndless;

    const string PLAYER_STRING = "Player";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        gameManagerEndless = FindFirstObjectByType<GameManagerEndless>();
    }

    void Update()
    {
        if (!player) return; // when player is not found or maybe destroyed
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EnemyHealthEndless enemyHealthEndless = GetComponent<EnemyHealthEndless>();
            enemyHealthEndless.SelfDestruct();
            gameManagerEndless.UpdateEnemiesKilled(1); // one enemy has been destroyed
        }
    }
}

