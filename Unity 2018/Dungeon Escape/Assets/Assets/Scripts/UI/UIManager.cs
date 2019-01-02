using UnityEngine;
using UnityEngine.UI;

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
  public Image SelectionImage;
  public Text GemCount;
  public Image[] LifeUnits;

  public void UpdateGemCount(int gemCount)
  {
    PlayerGemCountText.text = $"{gemCount.ToString()}G";
  }

  public void UpdateShopSelection(int yPos)
  {
    SelectionImage.rectTransform.anchoredPosition = new Vector2(SelectionImage.rectTransform.anchoredPosition.x, yPos);
  }

  public void UpdateGemCountText(int count)
  {
    GemCount.text = $"{count}";
  }

  public void UpdateLifes(int lifeRemaining)
  {
    for (int i = 0; i < LifeUnits.Length; i++)
    {
      if (i >= lifeRemaining)
      {
        LifeUnits[i].enabled = false;
      }
      else
      {
        LifeUnits[i].enabled = true;
      }
    }
  }

  private void Awake()
  {
    _instance = this;
  }
}
