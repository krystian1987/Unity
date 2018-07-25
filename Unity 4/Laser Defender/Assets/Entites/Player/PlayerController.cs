using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  public float speed = 5.0f;
  public float padding = 0.5f;
  public GameObject laserPrefab;

  private float xMin;
  private float xMax;
  public float projectileSpeed = 5f ;
  public float firingRate = 0.2f;
  public float health = 500;
  private LevelManager levelManager;

  // Use this for initialization
  void Start ()
  {
    levelManager = FindObjectOfType<LevelManager>();
    float distance = transform.position.z - Camera.main.transform.position.z;
    Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
    Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
    xMin = leftmost.x + padding;
    xMax = rightmost.x - padding;
  }
	
	// Update is called once per frame
	void Update ()
	{
	  MoveWithKey();
	  if (Input.GetKeyDown(KeyCode.Space))
	  {
      InvokeRepeating("Fire", 0.000001f, firingRate);
	  }
	  if (Input.GetKeyUp(KeyCode.Space))
    {
	    CancelInvoke("Fire");
	  }
	}

  void Fire()
  {
    GameObject beam = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
    beam.rigidbody2D.velocity = new Vector2(0, projectileSpeed);
  }

  void MoveWithKey()
  {
    if (Input.GetKey(KeyCode.RightArrow))
    {
      transform.position += Vector3.right * speed * Time.deltaTime;
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      transform.position += Vector3.left * speed * Time.deltaTime;
    }

    float newX = Mathf.Clamp(transform.position.x, xMin, xMax);

    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    LaserScript laser = col.gameObject.GetComponent<LaserScript>();
    if (laser)
    {
      health = health - laser.GetDamage();
      laser.Hit();
      if (health <= 0)
      {
        Die();
      }
    }
  }

  void Die()
  {
    levelManager.LoadNextLevel();
    Destroy(gameObject);
  }

}
