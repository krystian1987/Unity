using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour

{
  public GameObject ShopPanel;
  private 
  void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      Player player = collider2D.GetComponent<Player>();
      if (player != null)
      {
       UIManager.Instance.OpenShop(player.diamonds);
      }
      ShopPanel.SetActive(true);
    }
  }

  void OnTriggerExit2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      ShopPanel.SetActive(false);
    }
  }
}
