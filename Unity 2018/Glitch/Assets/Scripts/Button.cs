using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
  public GameObject DefenderPrefab;
  public static GameObject SelectedDefender;

  private Button[] buttonArray;

	// Use this for initialization
	void Start ()
	{
	  buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

  void OnMouseDown()
  {
    foreach (var item in buttonArray)
    {
      if (item == this)
      continue;

      item.GetComponent<SpriteRenderer>().color = Color.black;
    }

    GetComponent<SpriteRenderer>().color = Color.white;
    SelectedDefender = DefenderPrefab;
  }
}
