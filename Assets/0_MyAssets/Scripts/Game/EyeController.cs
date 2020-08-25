using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EyeController : MonoBehaviour
{
    public Action<Collider> OnTriggerEnterEye;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEye(other);
    }
}
