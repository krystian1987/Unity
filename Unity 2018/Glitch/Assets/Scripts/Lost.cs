using Assets.Scripts;
using UnityEngine;

namespace Assets
{
  public class Lost : MonoBehaviour
  {
    private LevelManager _levelManager;

    // Use this for initialization
    void Start ()
    {
      _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D()
    {
      _levelManager.LoadLevel("Lose");
    }
  }
}
