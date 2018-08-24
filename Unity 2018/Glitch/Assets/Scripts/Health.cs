using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

  public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}

  public void Destroy()
  {
    Destroy(gameObject);
  }

  public void DealDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
      Destroy();
  }
}
