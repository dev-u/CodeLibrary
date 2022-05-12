﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource audioSource;

    public string name;
	
    public AudioClip audio;

    [Range(0f, 1f)]
    public float volume;
	
    [Range(.1f, 3f)]
    public float pitch;
	
	public bool loop;
}
