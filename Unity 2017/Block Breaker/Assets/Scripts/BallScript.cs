using UnityEngine;

public class BallScript : MonoBehaviour
{
  private Paddle paddle;
  private bool hasStarted = false;

  private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start ()
	{
	  paddle = FindObjectOfType<Paddle>();
	  paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	  if (!hasStarted)
	  {
	    this.transform.position = paddle.transform.position + paddleToBallVector;

	    if (Input.GetMouseButtonDown(0))
	    {
	      hasStarted = true;
	      this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
	    }
	  }
	}

  void OnCollisionEnter2D(Collision2D collider)
  {
   Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

    if (hasStarted)
    {
      GetComponent<AudioSource>().Play();
      GetComponent<Rigidbody2D>().velocity += tweak;
    }
  }
}
