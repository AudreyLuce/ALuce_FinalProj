using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        GameObject theController = GameObject.Find("Game Controller");
        GameController gameScript = theController.GetComponent<GameController>();

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed * gameScript.speed;
    }
}
