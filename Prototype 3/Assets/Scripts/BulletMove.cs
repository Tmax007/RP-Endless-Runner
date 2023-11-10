using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //Bullet speed & damage
    public float bulletSpeed;
    public int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroys itself if it reaches the boundary at the edge of the screen
        if (collision.gameObject.name == "Top Boundary")
        {
            Destroy(gameObject);
            //Debug.Log("S");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys itself upon touching an enemy
        if (collision.gameObject.name == "LoweringEnemy(Clone)" || collision.gameObject.name == "RisingEnemy(Clone)")
        {
            Destroy(gameObject);
            //Debug.Log("S");
        }
    }
}
