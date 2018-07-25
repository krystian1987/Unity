using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
  public float speed = 1.0f;
  public GameObject enemyPrefab;
  public float width = 13.5f;
  public float height = 6.3f;

  public float padding = 0.5f;

  private float xMin;
  private float xMax;

  private bool movingToLeft = false;
  private float spawnDeley= 0.5f;

  // Use this for initialization
  void Start ()
  {
    float distance = transform.position.z - Camera.main.transform.position.z;
    Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
    Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
    xMin = leftmost.x + padding+ (width/2);
    xMax = rightmost.x - padding- (width/2);

    SpawnUtileFull();
  }

  public void OnDrawGizmos()
  {
    Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
  }

  //void SpawnEnemies()
  //{
  //  foreach (Transform item in transform)
  //  {
  //    GameObject enemy = Instantiate(enemyPrefab, item.transform.position, Quaternion.identity) as GameObject;
  //    enemy.transform.parent = item;
  //  }
  //}

  void SpawnUtileFull()
  {
    Transform freePosition = NextFreePosition();
    if (freePosition != null)
    {
      GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
      enemy.transform.parent = freePosition;
    }
    if(NextFreePosition())
    {
      Invoke("SpawnUtileFull", spawnDeley);
    }
  }

  // Update is called once per frame
  void Update()
  {
    MoveFormation();
    if (AllMembersDead())
    {
      SpawnUtileFull();
    }
  }

  Transform NextFreePosition()
  {
    foreach (Transform childPositionGameObjeck in transform)
    {
      if (childPositionGameObjeck.childCount == 0)
      {
       return childPositionGameObjeck;
      }
    }
    return null;
  }

  private bool AllMembersDead()
  {
    foreach (Transform childPositionGameObjeck in transform)
    {
      if (childPositionGameObjeck.childCount > 0)
      {
        return false;
      }
    }
    return true;
  }

  void MoveFormation()
  {
    if (movingToLeft)
    {
      transform.position += Vector3.right * speed * Time.deltaTime;
    }
    else
    {
      transform.position += Vector3.left * speed * Time.deltaTime;
    }
    if (!(transform.position.x > xMin))
    {
      transform.position += Vector3.down * speed * Time.deltaTime;
      movingToLeft = true;
    }
    else if (!(transform.position.x < xMax))
    {
      transform.position += Vector3.down * speed * Time.deltaTime;
      movingToLeft = false;
    }
  }
}
