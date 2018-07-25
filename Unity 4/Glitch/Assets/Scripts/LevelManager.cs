using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

  public float autoLoadNextLevel;

  void Start()
  {
    if (autoLoadNextLevel != 0)
    {
      Invoke("LoadNextLevel", autoLoadNextLevel);
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

  public void BrickDestoyed()
  {
    if (Brick.breakableCount <= 0)
    {
      LoadNextLevel();
    }
  }

}
