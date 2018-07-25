using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Brick : MonoBehaviour
{
  public AudioClip crack;
  public Color[] hitColors;
  public static int breakableCount = 0;
  public GameObject smoke;

  private int timeHit;
  private LevelManager levelManager;
  private bool isBreakable;
  private GameObject smokeInstantiate;


  // Use this for initialization
  void Start ()
  {
    isBreakable = this.tag == "Breakable";
    smoke.particleSystem.Stop();
    smokeInstantiate = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
    smokeInstantiate.particleSystem.Stop();

    if (isBreakable)
    {
      breakableCount++;
    }
    levelManager = FindObjectOfType<LevelManager>();
    timeHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D(Collision2D collider)
  {
    AudioSource.PlayClipAtPoint(crack, transform.position, 0.7f);

    if (isBreakable)
    {
      smokeInstantiate.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
      smokeInstantiate.particleSystem.Play();
      HandleHit();
    }
  }

  void HandleHit()
  {
    timeHit++;

    if (timeHit >= hitColors.Length + 1)
    {
      breakableCount--;
      levelManager.BrickDestoyed();
      Destroy(gameObject);
    }
    else
      LoadSprites();
  }

  private void LoadSprites()
  {
    try
    {
      GetComponent<SpriteRenderer>().color = hitColors[timeHit - 1];
    }
    catch (Exception e)
    {
      Debug.LogException(e);
    }
  }
}
