using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 6f;


    void Start()
        {

        Cursor.lockState = CursorLockMode.Locked;

    }
    // https://www.youtube.com/watch?v=4HpC--2iowE


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (horizontal, vertical, 0).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction *  speed * Time.deltaTime);
        }
    }



}
