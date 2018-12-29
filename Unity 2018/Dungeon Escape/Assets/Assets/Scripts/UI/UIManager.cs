using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Persistence;

public class UIManager : MonoBehaviour
{

  private static UIManager _instance;

  public static UIManager Instance
  {
    get
    {
      if (_instance == null)
      {
        throw new UnityException("UIManager instance is null.");
      }
      return _instance;
    }
  }

  public Text PlayerGemCountText;

  public void OpenShop(int gemCount)
  {
    PlayerGemCountText.text = $"{gemCount.ToString()}G";
  }

  private void Awake()
  {
    _instance = this;
  }
}
