using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform center;
    Rigidbody[] rigidbodies;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }


    void Update()
    {

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            var vec = Vector3.Cross(rigidbodies[i].transform.position - center.position, Vector3.forward);
            if (vec.y > 0) continue;
            if (vec.x < 0) continue;
            rigidbodies[i].velocity = vec * 10;
        }
    }
}
