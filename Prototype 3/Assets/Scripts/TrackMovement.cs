using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour
{

    public float movSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * movSpeed * Time.deltaTime);
    }
}
