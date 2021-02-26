using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Comandi;
    public GameObject QuestWindow;
    public GameObject Componenti;


    // Update is called once per frame
    void Update()
    {
        if (!Componenti.activeSelf) {
            if (!Comandi.activeSelf)
            {
                if (!QuestWindow.activeSelf)
                {

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        if (GameIsPaused)
                        {

                            Resume();
                        }
                        else
                        {
                            Pause();
                        }
                    }
                }
            }
        }


    }

    public void Pause()
    {
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }   

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Stop("Rob_Drums");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
