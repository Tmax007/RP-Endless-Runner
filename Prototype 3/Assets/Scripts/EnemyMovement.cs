using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    // Direction, movement speed, & health
    public Vector3 moveDirection;
    public float moveSpeed;
    public int health;

    // String used to denote barrier that destroys enemies when they reach it
    public string destroyBarrier;

    // Displays health
    TextMeshProUGUI healthDisplay;

    // Reference for the player
    GameObject player;
    PlayerMovement playerLink;

    // Reference for score UI
    GameObject scoUI;
    ScoreUI getScore;

    // Time to live in seconds
    public float timeToLive = 10f;
    private float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Gets reference for the player upon instantiating
        healthDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        player = GameObject.Find("Player");
        playerLink = player.GetComponent<PlayerMovement>();

        // Gets reference for the score UI
        scoUI = GameObject.Find("Score UI");
        getScore = scoUI.GetComponent<ScoreUI>();

        // Initialize destroy timer
        destroyTimer = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // If health reaches 0, destroys itself & adds value to the player's health regen number
        if (health <= 0)
        {
            Destroy(gameObject);
            playerLink.healthRegainNum++;
            getScore.scoreNum += 10;
        }

        // Update destroy timer
        destroyTimer -= Time.deltaTime;

        // If destroy timer reaches zero, destroy the enemy
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();
    }

    // Destroys itself when reaching specified barrier
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == destroyBarrier)
        {
            Destroy(gameObject);
        }
    }

    // Takes damage when touching bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            BulletMove bulletStats = collision.GetComponent<BulletMove>();
            health -= bulletStats.bulletDamage;
            Debug.Log(health);
        }
    }
}