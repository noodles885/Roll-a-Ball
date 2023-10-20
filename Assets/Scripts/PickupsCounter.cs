using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

    
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }


    }

    public void SetCountText()
    {

        countText.text = "Points: " + count.ToString() + "/20";
        if (count >= 20)
        {

            winTextObject.SetActive(true);
            Time.timeScale = 0f;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
