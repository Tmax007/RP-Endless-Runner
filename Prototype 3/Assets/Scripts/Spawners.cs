using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    //Reference for the spawners & enemy prefab
    public GameObject[] enemySpawners;
    public GameObject enemy;

    //Minimum & maximum number of enemies spawned per wave
    public int minPerWave;
    public int maxPerWave;

    //Delays used for invoking the spawn method
    public float initialDelayInSeconds;
    public float delayInSeconds;

    //Rotation value when instantiating enemies
    public float rotate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", initialDelayInSeconds, delayInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //Spawns enemies via Random algorithm. Randomly selects a random number of spawners from the array & has them spawn enemies
    void spawn()
    {
        int spawnNum = Random.Range(minPerWave, maxPerWave);

        for(int i = 0; i < spawnNum; i++)
        {
            int spawnIndex = Random.Range(0, enemySpawners.Length - 1);

            SpawnBool spawnCheck = enemySpawners[spawnIndex].GetComponent<SpawnBool>();

            if(spawnCheck.hasSpawned == false)
            {
                //Debug.Log("A");
                Instantiate(enemy, enemySpawners[spawnIndex].transform.position, Quaternion.Euler(0, 0, rotate));
                spawnCheck.hasSpawned = true;
            }

            else
            {
                i--;
            }
        }

        for(int i = 0; i < enemySpawners.Length; i++)
        {
            SpawnBool spawnCheck = enemySpawners[i].GetComponent<SpawnBool>();
            spawnCheck.hasSpawned = false;
        }
    }
}
