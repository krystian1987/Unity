﻿using UnityEngine;

namespace Assets.Scripts
{
  public class Shredder : MonoBehaviour
  {

    void OnTriggerEnter2D(Collider2D collider)
    {
      Destroy(collider.gameObject);
    }

  }
}
