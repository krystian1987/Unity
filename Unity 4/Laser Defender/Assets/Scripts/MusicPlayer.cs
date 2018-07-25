﻿using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   static MusicPlayer Instance = null;

  public AudioClip StartClip;
  public AudioClip GameClip;
  public AudioClip EndClip;

  private AudioSource music;

  void Start()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      print("Duplicate music player self-destructing!");
    }
    else
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
      music = GetComponent<AudioSource>();
      music.clip = StartClip;
      music.loop = true;
      music.Play();
    }
  }

  void OnLevelWasLoaded(int level)
  {
    music.Stop();
    if (level == 0)
    {
      music.clip = StartClip;
    }
    if (level == 1)
    {
      music.clip = GameClip;
     
    }
    if (level == 2)
    {
      music.clip = EndClip;
    }

    music.loop = true;
    music.Play();
  }
}
