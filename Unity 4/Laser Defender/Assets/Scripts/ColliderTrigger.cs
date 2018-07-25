using UnityEngine;
using System.Collections;

public class ColliderTrigger : MonoBehaviour
{
  private LevelManager levelManager;

  void Start()
  {
    levelManager = FindObjectOfType<LevelManager>();
  }

  void  OnCollisionEnter2D(Collision2D collider)
  {
    print("Collider");
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    levelManager.LoadLevel("Lose");
  }
}
