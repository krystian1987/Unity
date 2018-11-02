using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
  [RequireComponent(typeof(Text))]
  public class StarDisplay : MonoBehaviour
  {
    private Text _text;
    private int _stars = 10000;

    public enum Status
    {
      SUCCESS, FAILURE
    }

    // Use this for initialization
    void Start ()
    {
      _text = GetComponent<Text>();
      UpdateStarDisplay();
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void AddStars(int amount)
    {
      AddStarsAmount(amount);
    }

    public Status UseStrars(int amount)
    {
      if (_stars >= amount)
      {
        _stars -= amount;
        UpdateStarDisplay();
        return Status.SUCCESS;
      }

      return Status.FAILURE;
    }

    private void AddStarsAmount(int amount)
    {
      _stars += amount;
      UpdateStarDisplay();
    }

    private void UpdateStarDisplay()
    {
      _text.text = _stars.ToString();
    }
  }
}
