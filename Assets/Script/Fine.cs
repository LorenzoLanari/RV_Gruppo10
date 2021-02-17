using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Soundtrack");
    }

   public void MenuButton()
    {
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        SceneManager.LoadScene(0);
    }
}
