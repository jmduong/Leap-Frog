using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAway : MonoBehaviour {

    private float speed = 0.5f;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();         //Grant rigidbody component.
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 movement = new Vector3(0, 0, -speed);    //Move the object

        rb.position += movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "End")
        {
            Destroy(gameObject);
        }
    }
}
