using UnityEngine;

namespace Assets.Scripts
{
  public class DefenderSpawner : MonoBehaviour
  {
    public Camera MyCamera;
    private GameObject _parent;
    private StarDisplay _starDisplay;

    // Use this for initialization
    void Start () {
      _parent = GameObject.Find("Defenders");
      _starDisplay = GameObject.FindObjectOfType<StarDisplay>();
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
      Vector2 roundedPos = SnapToGrid(CalculatedWorldPointOfMouseClick());
      GameObject defender = Button.SelectedDefender;
      int defenderCosyt = defender.GetComponent<Defender>().StarCost;
      if (_starDisplay.UseStrars(defenderCosyt) == StarDisplay.Status.SUCCESS)
      {
        SpawneDefender(defender, roundedPos);
      }
      else
      {
        
      }
    }

    private void SpawneDefender(GameObject defender, Vector2 roundedPos)
    {
      Quaternion zeroRot = Quaternion.identity;
      GameObject newDefender = Instantiate(defender, roundedPos, zeroRot) as GameObject;

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
}
