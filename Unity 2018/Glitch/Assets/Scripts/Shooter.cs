using UnityEngine;

namespace Assets.Scripts
{
  public class Shooter : MonoBehaviour
  {
    public GameObject Projectile;
    public GameObject Gun;
    private GameObject _projectileParent;
    private Animator _animation;
    private Spawner _mySpawner;
  
    void Start()
    {
      _animation = gameObject.GetComponent<Animator>();
      _projectileParent = GameObject.Find("Projectiles");
      if (_projectileParent == null)
      {
        _projectileParent = new GameObject("Projectiles");
      }
      SetMyLandpawner();
    }

    void Update()
    {
      if (IsAttackerAheadInLane())
      {
        _animation.SetBool("IsAttacking", true);
      }
      else
      {
        _animation.SetBool("IsAttacking", false);
      }
    }

    void SetMyLandpawner()
    {
      Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
      foreach (var item in spawnerArray)
      {
        if (item.transform.position.y == transform.position.y)
        {
          _mySpawner = item;
          return;
        }
      }
      Debug.LogError(name + " can't fin spawner in lane");
    }

    private bool IsAttackerAheadInLane()
    {
      if (_mySpawner.transform.childCount <= 0)
        return false;

      bool isAttackerAheadInLane = false;

      foreach (Transform item in _mySpawner.transform)
      {
        if (item.transform.position.x > transform.position.x)
          isAttackerAheadInLane = true;
      }

      return isAttackerAheadInLane;
    }

    private void Fire()
    {
      GameObject newProjectile = Instantiate(Projectile) as GameObject;
      newProjectile.transform.parent = _projectileParent.transform;
      newProjectile.transform.position = Gun.transform.position;
    }
  }
}
