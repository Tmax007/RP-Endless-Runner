using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Player speed & rigidbody reference
    Rigidbody2D rb;
    public float speed;

    //Bullet object reference
    public GameObject bullet;
    
    //Player health values
    public int health;

    //Player invincibility boolean & invincibility duration float
    bool invincible = false;
    public float invincibilityTime;

    //Value that must be reached to regaiin health
    public int healthRegainThreshold;
    [HideInInspector]
    //Value that increase each time the player kills an enemy
    public int healthRegainNum = 0;

    TextMeshProUGUI healthDisplay;

    //Get reference to Score UI
    GameObject scoUI;
    ScoreUI getScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        //Reference to Score UI
        scoUI = GameObject.Find("Score UI");
        getScore = scoUI.GetComponent<ScoreUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        //Moving vertically
        if (Input.GetKey("up")) {

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            //Debug.Log("moving up");
        }
        else if (Input.GetKey("down")){

            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

            //Debug.Log("moving down");
        }
        */

        //Moving horizontally
        if (Input.GetKey("right")) {

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
   
            //Debug.Log("moving right");
        }
        else if (Input.GetKey("left")) {

            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

            //Debug.Log("moving left");
        }


        //Handles shooting
        if (Input.GetKeyDown(KeyCode.Z)) {

            Instantiate(bullet, transform.position, Quaternion.identity);
            //Debug.Log("Shooting");
        }

        //Death checker
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        //Displays health
        healthDisplay.text = health.ToString();

        healthRegainNum = getScore.scoreNum;

        //Regains health if threshold is met
        if(healthRegainNum == healthRegainThreshold)
        {
            health++;
            healthRegainNum = 0;
            healthRegainThreshold += 50;
            Debug.Log("Threshold: " + healthRegainThreshold);
        }
    }

    //Checks if the player touches any of the enemy types while not being invincible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LoweringEnemy(Clone)" && invincible == false || collision.gameObject.name == "RisingEnemy(Clone)" && invincible == false)
        {
            takeDamage();
        }
    }

    //Damage reaction & invincibility beginning for the player
    void takeDamage()
    {
        invincible = true;
        health--;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.black;
        StartCoroutine(BecomeVulnerable());
        
    }

    //Invincibility ending for the player
    IEnumerator BecomeVulnerable()
    {
        yield return new WaitForSeconds(invincibilityTime);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.white;

        invincible = false;
    }
}
