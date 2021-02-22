using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup audioMixerGroup;
    

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [Range(0f, 1f)]
    public float Spatial3D;

    public bool loop;


    [HideInInspector]
    public AudioSource source;
}
