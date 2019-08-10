using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Transform subT;
    Transform T;
    Quaternion oldRot;
    bool jumping = false;

    public int mode;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        subT = this.gameObject.transform.GetChild(0);
        T = this.GetComponent<Transform>();
        rb.velocity = Vector3.forward * 0.1f;

        oldRot = T.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { jumping = true; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W)){rb.AddForce(new Vector3(  0, 0, 1500));}
        if (Input.GetKey(KeyCode.S)){rb.AddForce(new Vector3(  0, 0,-1500));}
        if (Input.GetKey(KeyCode.A)){rb.AddForce(new Vector3(-1500, 0,  0));}
        if (Input.GetKey(KeyCode.D)){rb.AddForce(new Vector3( 1500, 0,  0));}

        if (jumping) { rb.AddForce(new Vector3(0, 40000, 0)); jumping = false; }
        
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity *= 0.9f;
        }

        if(rb.velocity.magnitude > 25f)
        {
            rb.velocity = rb.velocity.normalized * 25f;
        }
        if (mode == 0)
        {
            //subT.transform.rotation = subT.rotation * T.rotation * Quaternion.Inverse(oldRot);
            
        }else if (mode == 1)
        {
            Quaternion rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(new Vector3(0, 0, 90));
            Quaternion rotationM = T.rotation * Quaternion.Euler(new Vector3(0, 0, 90));
            subT.rotation = Quaternion.Slerp(rotationM, rotation, .5f);
        } else if (mode == 2)
        {
            Quaternion rotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(new Vector3(0, 0, 90));
            subT.rotation = rotation;
        } else if (mode == 3)
        {
            Quaternion Targetrotation = Quaternion.LookRotation(rb.velocity) * Quaternion.Euler(new Vector3(0, 0, 90));
            subT.rotation = Quaternion.RotateTowards(T.rotation, Targetrotation, 1f);
        }

        oldRot = T.rotation;
    }
}
