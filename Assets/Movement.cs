using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)){rb.AddForce(new Vector3(  0, 0, 10));}
        if (Input.GetKey(KeyCode.S)){rb.AddForce(new Vector3(  0, 0,-10));}
        if (Input.GetKey(KeyCode.A)){rb.AddForce(new Vector3(-10, 0,  0));}
        if (Input.GetKey(KeyCode.D)){rb.AddForce(new Vector3( 10, 0,  0));}

        if(rb.velocity.magnitude > 10f)
        {
            rb.velocity = rb.velocity.normalized * 10f;
        }

    }
}
