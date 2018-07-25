using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour
{
  private int _max;
  private int _min;
  private int _guess;

  // Use this for initialization
  void Start()
  {
    StartGame();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      _min = _guess;
      SetGuess();
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      _max = _guess;
      SetGuess();
    }
    else if (Input.GetKeyDown(KeyCode.Return))
    {
      print("I won!");
      StartGame();
    }
  }

  private void SetGuess()
  {
    _guess = (_max + _min) / 2;
    print("Higher or lower that " + _guess);
    print("Up arrow for higher, down arrow for lower or return for equals");
  }


  private void StartGame()
  {
    _max = 1000;
    _min = 1;
    _guess = 500;
    print("============================");
    print("Welcome to Number Wizard");
    print("Pick a number in your head, but don't tell me.");

    print("The highest number you can pick is " + _max);
    print("The lowest number you can pick is " + _min);

    print("is the number higher or lower that " + _guess + "?");
    _max = _max + 1;
  }
}
