using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Dissolvenza dissolvenza;
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        dissolvenza.gameObject.SetActive(true);
        dissolvenza.LoadNextLevel();
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
