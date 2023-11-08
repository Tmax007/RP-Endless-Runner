using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up")) {

            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            Debug.Log("moving up");
        }
        else if (Input.GetKey("down")){

            rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
            Debug.Log("moving down");
        }
        else if (Input.GetKey("right")) {

            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            Debug.Log("moving right");
        }
        else if (Input.GetKey("left")) {

            rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            Debug.Log("moving left");
        }
        
    }
}
