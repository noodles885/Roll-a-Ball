using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    private float movementx;
    private float movementy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementx = movementVector.x;
        movementy = movementVector.y;
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementx,0.0f, movementy);

        rb.AddForce(movement * speed); 
    }

}
