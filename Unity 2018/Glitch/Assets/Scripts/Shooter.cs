using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Shooter : MonoBehaviour
{
  public GameObject Projectile;
  public GameObject Gun;
  private GameObject projectileParent;
  private Animator animation;
  private Spawner mySpawner;
  
  void Start()
  {
    animation = gameObject.GetComponent<Animator>();
    projectileParent = GameObject.Find("Projectiles");
    if (projectileParent == null)
    {
      projectileParent = new GameObject("Projectiles");
    }
    SetMyLandpawner();
  }

  void Update()
  {
    if (IsAttackerAheadInLane())
    {
      animation.SetBool("IsAttacking", true);
    }
    else
    {
      animation.SetBool("IsAttacking", false);
    }
  }

  void SetMyLandpawner()
  {
    Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
    foreach (var item in spawnerArray)
    {
      if (item.transform.position.y == transform.position.y)
      {
        mySpawner = item;
        return;
      }
    }
    Debug.LogError(name + " can't fin spawner in lane");
  }

  private bool IsAttackerAheadInLane()
  {
    if (mySpawner.transform.childCount <= 0)
      return false;

    bool isAttackerAheadInLane = false;

    foreach (Transform item in mySpawner.transform)
    {
      if (item.transform.position.x > transform.position.x)
        isAttackerAheadInLane = true;
    }

    return isAttackerAheadInLane;
  }

  private void Fire()
  {
    GameObject newProjectile = Instantiate(Projectile) as GameObject;
    newProjectile.transform.parent = projectileParent.transform;
    newProjectile.transform.position = Gun.transform.position;
  }
}
