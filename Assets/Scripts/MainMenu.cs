using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool Paused = false;
    public GameObject MainCanvas;
    public GameObject OptionsMenu;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Paused)
            {

                OptionsMenu.SetActive(true);
                MainCanvas.SetActive(false);
                Paused = false;

            }
            else
            {

                OptionsMenu.SetActive(false);
                MainCanvas.SetActive(true);
                Paused = true;

            }
        }

    }
    

    public void Play()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {

        Application.Quit();
        Debug.Log("Player has quit the game");

    }

}