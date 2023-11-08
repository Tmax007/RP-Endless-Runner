using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) {

            Debug.Log("moving up");
        }
        else if (Input.GetKey("down"){

            Debug.Log("moving down");
        }
        else if (Input.GetKey("right")) {

            Debug.Log("moving right");
        }
        else if (Input.GetKey("left")) {

            Debug.Log("moving left");
        }
        
    }
}
