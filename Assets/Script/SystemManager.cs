using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rob;
    public Dissolvenza dissolvenza;
    private bool load = false;
    void Start()
    {
        Rob = GameObject.FindGameObjectWithTag("Player");
    }

    public void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Rob.GetComponent<TPC_Rob>().dead && !load)
        {
            load = true;
            Invoke("LoadSceneOnDeath", 7f);
        }


    }

    public void LoadSceneOnDeath()
    {
        
        dissolvenza.ReloadLevel();
    }
}
