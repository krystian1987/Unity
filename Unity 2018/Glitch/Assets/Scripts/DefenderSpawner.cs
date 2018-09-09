using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
  public Camera MyCamera;
  private GameObject _parent;

  // Use this for initialization
  void Start () {
	  _parent = GameObject.Find("Defenders");
	  if (_parent == null)
	  {
	    _parent = new GameObject("Defenders");
	  }
  }
	
	// Update is called once per frame
  void Update()
  {
  }

  void OnMouseDown()
  {
    GameObject newDefender = Instantiate(Button.SelectedDefender, SnapToGrid(CalculatedWorldPointOfMouseClick()), Quaternion.identity) as GameObject;

    newDefender.transform.parent = _parent.transform;
  }

  Vector2 SnapToGrid(Vector2 rawWorldPos)
  {
    return new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
  }

  Vector2 CalculatedWorldPointOfMouseClick()
  {
    float mouseX = Input.mousePosition.x;
    float mouseY = Input.mousePosition.y;
    float distanceFromCamera = 10f;

    Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
    Vector2 worldPos = MyCamera.ScreenToWorldPoint(weirdTriplet);

    return worldPos;
  }
}
