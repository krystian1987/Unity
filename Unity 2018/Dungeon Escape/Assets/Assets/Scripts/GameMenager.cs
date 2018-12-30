using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
  private static GameMenager _instance;

  public static GameMenager Instance
  {
    get
    {
      if (_instance == null)
      {
        throw new UnityException("GameMenager instance is null.");
      }
      return _instance;
    }
  }

  public bool HasKeyToCastle { get; set; }

  private void Awake()
  {
    _instance = this;
  }
}
