using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform center;
    Rigidbody[] rigidbodies;
    float speed;
    EyeController[] eyeControllers;
    bool isPressed;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        eyeControllers = GetComponentsInChildren<EyeController>();
        foreach (var item in eyeControllers)
        {
            item.OnTriggerEnterEye = OnTriggerEnterEye;
        }
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

    void OnTriggerEnterEye(Collider other)
    {
        Pressed(other);
    }

    void Goal(Collider other)
    {
        if (other.gameObject.CompareTag("Goal") == false) { return; }
        if (Variables.screenState == ScreenState.Game) return;
        Variables.screenState = ScreenState.Clear;
    }

    void Pressed(Collider other)
    {
        if (isPressed) return;
        if (other.gameObject.CompareTag("Trap") == false) { return; }

        isPressed = true;
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
        transform.localScale = new Vector3(1, 0.1f, 1);
        transform.position -= Vector3.up * 2.5f;
        DOVirtual.DelayedCall(1.5f, () =>
        {
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.up * 2.5f;
            isPressed = false;
        });
    }

}
