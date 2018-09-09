using UnityEngine;

public class Shooter : MonoBehaviour
{
  public GameObject Projectile;
  
  public GameObject Gun;

  private GameObject projectileParent;

  void Start()
  {
    projectileParent = GameObject.Find("Projectiles");
    if (projectileParent == null)
    {
      projectileParent = new GameObject("Projectiles");
    }
  }

  private void Fire()
  {
    
    GameObject newProjectile = Instantiate(Projectile) as GameObject;
    newProjectile.transform.parent = projectileParent.transform;
    newProjectile.transform.position = Gun.transform.position;
  }
}
