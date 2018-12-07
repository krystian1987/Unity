using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	  Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	  transform.Translate(Vector3.right * 3 * Time.deltaTime);
	}

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      IDamageable hit = collider2D.GetComponent<IDamageable>();
      if (hit != null)
      {
        hit.Damage(1);
        Destroy(gameObject);
      }
    }
  }
}
