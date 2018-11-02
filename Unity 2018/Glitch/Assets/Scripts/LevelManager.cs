using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
  public class LevelManager : MonoBehaviour
  {
    public float AutoLoadNextLevelInSeconds;

    void Start()
    {
      if (AutoLoadNextLevelInSeconds > 0)
      {
        Invoke("LoadNextLevel", AutoLoadNextLevelInSeconds);
      }
      else
      {
        Debug.LogWarning("Level auto load disabled, set a positive number for seconds.");
      }
    }


    public void LoadLevel(string name)
    {
      SceneManager.LoadScene(name);
      Debug.Log("Level load requested for: " + name);
    }

    public void ExitLevel(string name)
    {
      Application.Quit();
      Debug.Log("Level exit requested for: " + name);
    }

    public void LoadNextLevel()
    {
      SceneManager.LoadScene(Application.loadedLevel + 1);
    }
  }
}
