using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
  public int gem = 1;

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      Player player = collider2D.GetComponent<Player>();
      if (player != null)
      {
        player.AddGems(gem);
        Destroy(gameObject);
      }
    }
  }
}
