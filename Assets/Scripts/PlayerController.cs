using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public Vector3 jump;
    public float jumpForce = 2.0f; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void SetCountText()
    {
        countText.text = "Points: " + count.ToString() + "/12";
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        
        
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(jump * jumpForce);

            isGrounded = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

}