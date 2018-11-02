using UnityEngine;

namespace Assets.Scripts
{
  public class Defender : MonoBehaviour
  {
    public int StarCost = 100;

    private StarDisplay _starDisplay;

    void Start()
    {
      _starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
      _starDisplay.AddStars(amount);
    }
  }
}
