using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
  private string _scoreConst = "Score : ";
  public static int ScoreValue = 0;
  private Text _scoreText;

  void Start()
  {
    _scoreText = GetComponent<Text>();
    Reset();
  }

  public void Score(int points)
  {
    ScoreValue += points;
    _scoreText.text = String.Format("{0}{1}", _scoreConst, ScoreValue);
  }

  public static void Reset()
  {
    ScoreValue = 0;
  }
}
