using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
  public class Button : MonoBehaviour
  {
    public GameObject DefenderPrefab;
    public static GameObject SelectedDefender;

    private Button[] _buttonArray;
    private Text _costText;

    // Use this for initialization
    void Start ()
    {
      _buttonArray = GameObject.FindObjectsOfType<Button>();

      _costText = gameObject.GetComponentInChildren<Text>();
      if (!_costText)
      {
        Debug.LogWarning($"{name} has not COST TEXT");
        return;
      }
      
      var starCost=DefenderPrefab.GetComponent<Defender>().StarCost;
      
      _costText.text = starCost.ToString();
    }
	
    // Update is called once per frame
    void Update ()
    {
    }

    void OnMouseDown()
    {
      foreach (var item in _buttonArray)
      {
        if (item == this)
          continue;

        item.GetComponent<SpriteRenderer>().color = Color.black;
      }

      GetComponent<SpriteRenderer>().color = Color.white;
      SelectedDefender = DefenderPrefab;
    }
  }
}
