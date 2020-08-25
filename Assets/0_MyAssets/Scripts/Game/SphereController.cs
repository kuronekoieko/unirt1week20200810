using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
            transform.position = startPos;
        }
        var vel = rb.velocity;
        vel.z = -speed;
        rb.velocity = vel;
    }
}
