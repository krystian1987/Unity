using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
  public AudioClip destroyAudio;
  public float health = 200;
  public GameObject laserPrefab;
  public float projectileSpeed = 5f;
  public float shotsPerSeconds = 0.5f;
  public int _scoreValue = 150;
  private ScoreKeeper _scoreKeeper;

  void Start()
  {
   _scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    LaserScript laser = col.gameObject.GetComponent<LaserScript>();
    if (laser)
    {
      health -= laser.GetDamage();
      laser.Hit();
      if (health <= 0)
      {
        _scoreKeeper.Score(_scoreValue);
        AudioSource.PlayClipAtPoint(destroyAudio, transform.position, 0.7f);
        Destroy(gameObject);
      }
    }
  }

  void Update()
  {
    float probability = shotsPerSeconds * Time.deltaTime;
    if (Random.value < probability)
    {
      Fire();
    }
  }

  void Fire()
  {
    GameObject beam = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
    beam.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
   ;
  }
}
