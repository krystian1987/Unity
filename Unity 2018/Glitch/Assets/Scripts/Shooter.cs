using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  public GameObject Projectile;
  public GameObject ProjectileParent;
  public GameObject Gun;

  private void Fire()
  {
    GameObject newProjectile = Instantiate(Projectile) as GameObject;
    newProjectile.transform.parent = ProjectileParent.transform;
    newProjectile.transform.position = Gun.transform.position;
  }
}
