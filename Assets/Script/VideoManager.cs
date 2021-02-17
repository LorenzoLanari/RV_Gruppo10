using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer video;
    public Dissolvenza dissolvenza;
    
    void Start()
    {
        video = gameObject.GetComponent<VideoPlayer>();
        
            dissolvenza.gameObject.SetActive(true);
           
        
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
