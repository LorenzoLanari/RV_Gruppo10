using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer video;
    public Dissolvenza dissolvenza;
    
    void Awake()
    {
        Cursor.visible = false;
        dissolvenza.gameObject.SetActive(true);
        video = gameObject.GetComponent<VideoPlayer>();
  
    }
    

    // Update is called once per frame
    void Update()
    {
        

        if (!video.isPlaying && video.isPrepared)
        {
      
            dissolvenza.LoadNextLevel();
        }
    }
}
