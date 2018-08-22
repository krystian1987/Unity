using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

  public float autoLoadNextLevelInSeconds;

  void Start()
  {
    if (autoLoadNextLevelInSeconds > 0)
    {
      Invoke("LoadNextLevel", autoLoadNextLevelInSeconds);
    }
    else
    {
      Debug.LogWarning("Level auto load disabled, set a positive number for seconds.");
    }
  }


  public void LoadLevel(string name)
  {
    Application.LoadLevel(name);
    Debug.Log("Level load requested for: " + name);
  }

  public void ExitLevel(string name)
  {
    Application.Quit();
    Debug.Log("Level exit requested for: " + name);
  }

  public void LoadNextLevel()
  {
    Application.LoadLevel(Application.loadedLevel + 1);
  }
}
