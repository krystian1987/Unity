using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
  public AudioClip laserAudio;
  public float damage = 100f;

  void Start()
  {
    AudioSource.PlayClipAtPoint(laserAudio, transform.position, 0.7f);
  }

  public float GetDamage()
  {
    return damage;
  }

  public void Hit()
  {
    Destroy(gameObject);
  }
}
