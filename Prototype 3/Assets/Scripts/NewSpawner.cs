using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("SpawnZone"))
        {
            Debug.Log("Working");
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 180));
            Destroy(gameObject);
        }
    }
}
