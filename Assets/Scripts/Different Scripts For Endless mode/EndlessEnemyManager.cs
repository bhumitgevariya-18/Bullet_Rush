using UnityEngine;
using System.Collections;

public class EndlessEnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    private Vector3[] spawnPositions;

    void Start()
    {
        spawnPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            spawnPositions[i] = enemies[i].transform.position;
        }
    }
    public void RespawnEnemy(int index)
    {
        StartCoroutine(RespawnAfterDelay(index));
    }

    private IEnumerator RespawnAfterDelay(int index)
    {
        yield return new WaitForSeconds(5f);

        GameObject newEnemy = Instantiate(enemies[index], spawnPositions[index], Quaternion.identity);
        newEnemy.GetComponent<EnemyHealthEndless>().enemyIndex = index; // Set the enemy index for health script
        enemies[index] = newEnemy;
    }
}
