using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

  public bool autPlay = false;

  private BallScript ball;

	// Use this for initialization
	void Start () {
	  ball = FindObjectOfType<BallScript>();
  }
	
	// Update is called once per frame
	void Update ()
	{
	  if (!autPlay)
	  {
	    MoveWithMouse();
    }
	  else
	  {
	    AutoPlay();
	  }
	}

  private void AutoPlay()
  {
    this.transform.position =
      new Vector3(
        Mathf.Clamp(ball.transform.position.x, 0 + (this.transform.localScale.x * 0.5f),
          16f - (this.transform.localScale.x * 0.5f)), this.transform.position.y, 0f);
  }

  void MoveWithMouse()
  {
    float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

    this.transform.position =
      new Vector3(
        Mathf.Clamp(mousePosInBlocks, 0 + (this.transform.localScale.x * 0.5f),
          16f - (this.transform.localScale.x * 0.5f)), this.transform.position.y, 0f);
  }
}
