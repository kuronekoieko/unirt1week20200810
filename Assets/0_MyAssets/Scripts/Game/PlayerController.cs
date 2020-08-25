using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform center;
    Rigidbody[] rigidbodies;
    float speed;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }


    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += Time.deltaTime * 3;
        }
        else
        {
            speed -= Time.deltaTime * 3;
        }
        speed = Mathf.Clamp(speed, 0, 10);

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            var vec = Vector3.Cross(rigidbodies[i].transform.position - center.position, Vector3.forward);
            if (vec.x < 0) continue;
            vec.y /= 2;
            vec.x *= 2;
            rigidbodies[i].velocity = vec * speed;
        }
    }
}
