using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rob;
    public Dissolvenza dissolvenza;
    public GameObject deadText;
    void Awake()
    {
        Invoke("PlayTheme", 2f);
        Rob = GameObject.FindGameObjectWithTag("Player");
    }

   

    // Update is called once per frame
    void Update()
    {

        if (Rob.GetComponent<TPC_Rob>().dead )
        {
            deadText.SetActive(true);
            Invoke("LoadSceneOnDeath", 7f);
        }


    }

    public void LoadSceneOnDeath()
    {
        
        dissolvenza.ReloadLevel();
    }

    public void PlayTheme()
    {
        FindObjectOfType<AudioManager>().Play("Rob_Drums");
    }
}
