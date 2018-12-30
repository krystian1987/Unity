using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
  public GameObject ShopPanel;
  private int _selectedItem = 1;
  private int _selectedItemCost = 200;
  private Player _player;

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      _player = collider2D.GetComponent<Player>();
      if (_player != null)
      {
        UIManager.Instance.UpdateShopSelection(136);
        UIManager.Instance.UpdateGemCount(_player.diamonds);
      }
      ShopPanel.SetActive(true);
    }
  }

  void OnTriggerExit2D(Collider2D collider2D)
  {
    if (collider2D.tag == "Player")
    {
      CloseShop();
    }
  }

  private void CloseShop()
  {
    ShopPanel.SetActive(false);
    _player = null;
  }

  public void SelectItem(int item)
  {
    _selectedItem = item;
    switch (item)
    {
      case 1:
        UIManager.Instance.UpdateShopSelection(136);
        _selectedItemCost = 200;
        break;
      case 2:
        UIManager.Instance.UpdateShopSelection(28);
        _selectedItemCost = 400;
        break;
      case 3:
        UIManager.Instance.UpdateShopSelection(-78);
        _selectedItemCost = 1000;
        break;
    }
  }

  public void BuyItem()
  {
    if (_player.diamonds >= _selectedItemCost)
    {
      if (_selectedItem == 3)
      {
        GameMenager.Instance.HasKeyToCastle = true;
      }

      _player.diamonds -= _selectedItemCost;
    }
    else
    {
      CloseShop();
      return;
    }
    UIManager.Instance.UpdateGemCount(_player.diamonds);
  }
}
