using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public float jumpForce = 5.0f; 
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
        Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
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

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.2f, movementY);

        rb.AddForce(movement * speed);

        
        isGrounded = true;
        
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            Jump();
            isGrounded = false;
        }
    }

    void Jump()
    {
        // Apply an upward force to make the player jump
        rb.AddForce(Jump * jumpForce, ForceMode.Impulse);
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