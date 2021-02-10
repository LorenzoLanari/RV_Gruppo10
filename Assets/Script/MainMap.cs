using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMap : MonoBehaviour
{
    public GameObject Menu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !Menu.activeSelf)
        {
           Menu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.M) && Menu.activeSelf)
        {
            Menu.SetActive(false);
        }
    }
}
