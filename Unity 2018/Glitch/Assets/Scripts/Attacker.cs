using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
  private float currentSpeed;
  private GameObject currentTargt;
  private Animator animator;

  // Use this for initialization
  void Start ()
	{
	  animator = GetComponent<Animator>();
  }
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	  if (currentTargt == null)
	    animator.SetBool("IsAttacking", false);
  }

  void OnTriggerEnter2D()
  {
    Debug.Log(name + " trigger enter");
  }

  public void SetCurrentSpeed(float speed)
  {
    currentSpeed = speed;
  }

  public void StrikeCurrentTarget(float damage)
  {
    if (currentTargt != null)
    {
      var health = currentTargt.GetComponent<Health>();
      if (health != null)
      {
        health.DealDamage(damage);
      }
    }
  }

  public void Attack(GameObject obj)
  {
    if (currentTargt == null)
    {
      currentTargt = obj;
    }
  }
}
