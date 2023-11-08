using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving vertically
        if (Input.GetKey("up")) {

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            Debug.Log("moving up");
        }
        else if (Input.GetKey("down")){

            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

            Debug.Log("moving down");
        }

        //Moving horizontally
        if (Input.GetKey("right")) {

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
   
            Debug.Log("moving right");
        }
        else if (Input.GetKey("left")) {

            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

            Debug.Log("moving left");
        }
    }
}
