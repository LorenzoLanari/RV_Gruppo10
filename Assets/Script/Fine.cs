using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fine : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        Invoke("PlaySoundtrack", 2f);
    }

   public void MenuButton()
    {
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        SceneManager.LoadScene(0);
    }

    public void PlaySoundtrack()
    {
        FindObjectOfType<AudioManager>().Play("Soundtrack");
    }
}
