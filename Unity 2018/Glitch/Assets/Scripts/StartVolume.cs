using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour
{
  private MusicPlayer musicPlayer;

  // Use this for initialization
  void Start () {
    musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
      musicPlayer.ChangeVolume(PlayerPrefManager.GetMasterVolume());
  }
}
