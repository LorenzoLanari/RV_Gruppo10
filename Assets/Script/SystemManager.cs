using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rob;
    void Start()
    {
        Rob = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Rob.GetComponent<TPC_Rob>().dead)
        {
            Invoke("LoadSceneOnDeath", 10f);
        }


    }

    public void LoadSceneOnDeath()
    {
        SceneManager.LoadScene("Rob_Scene_2");
    }
}
