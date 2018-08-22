using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [Range(0f,1f)]
  public float CurrentSpeed;

	// Use this for initialization
	void Start ()
	{
	  Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
	  myRigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
	}

  void OnTriggerEnter2D()
  {
    Debug.Log(name + " trigger enter");
  }

  public void SetCurrentSpeed(float speed)
  {
    CurrentSpeed = speed;
  }

  public void StrikeCurrentTarget(float damage)
  {
    Debug.Log(name + " caused damage: " +  damage);
  }
}
