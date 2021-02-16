using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rob;
    public Dissolvenza dissolvenza;
    
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Soundtrack");
        Rob = GameObject.FindGameObjectWithTag("Player");
    }

    

    // Update is called once per frame
    void Update()
    {

        if (Rob.GetComponent<TPC_Rob>().dead )
        {
            
            Invoke("LoadSceneOnDeath", 7f);
        }


    }

    public void LoadSceneOnDeath()
    {
        
        dissolvenza.ReloadLevel();
    }
}
