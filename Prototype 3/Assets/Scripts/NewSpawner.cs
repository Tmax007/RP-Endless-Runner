using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    public RhythmConductor rhythmConductor;

    public void SpawnEnemyPair()
    {
        Debug.Log("Attempting to spawn enemy pair");
        Instantiate(enemyPrefab, leftSpawnPoint.position, Quaternion.Euler(0, 0, 180));
        Instantiate(enemyPrefab, rightSpawnPoint.position, Quaternion.Euler(0, 0, 180));
        Debug.Log("Spawned enemies");

        gameObject.SetActive(false); // Deactivate instead of destroying
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger condition is met (e.g., player enters a specific zone)
        if (collision.gameObject.CompareTag("SpawnZone"))
        {
            rhythmConductor.UpdateSpawningLogic();
        }
    }
}