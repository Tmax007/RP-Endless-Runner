using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    //Direction, movement speed, & health
    public Vector3 moveDirection;
    public float moveSpeed;
    public int health;

    //String used to denote barrier that destroys enemies when they reach it
    public string destroyBarrier;

    //Displays health
    TextMeshProUGUI healthDisplay;

    //Reference for the player
    GameObject player;
    PlayerMovement playerLink;

    // Start is called before the first frame update
    void Start()
    {
        //Gets reference for the player upon instantiating
        healthDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        player = GameObject.Find("Player");
        playerLink = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        //If health reaches 0, destroys itself & adds value to the player's health regen number
        if(health <= 0)
        {
            Destroy(gameObject);
            playerLink.healthRegainNum++;
        }

        healthDisplay.text = health.ToString();
    }

    //Destroys itself when reaching specified barrier (NOT WORKING, SHOULD FIX FOR OPTIMIZATION)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == destroyBarrier)
        {
            //Debug.Log("A");
            Destroy(gameObject);
        }
    }

    //Takes damage when touching bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            BulletMove BulletStats = collision.GetComponent<BulletMove>();
            health = health - BulletStats.bulletDamage;
            Debug.Log(health);
        }
    }


}
