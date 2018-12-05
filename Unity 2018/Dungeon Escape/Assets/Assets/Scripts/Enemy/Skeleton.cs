using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemyBase, IDamageable
{
  public int Health { get; set; }

  public override void Init()
  {
    base.Init();
    Health = health;
  }

  public void Damage(int damageAmount)
  {
    
    Health -= damageAmount;
    Debug.Log("Hit " + this.name + " with damage " + damageAmount + " Health left: "+ Health);
    IsHit = true;
    Animator.SetTrigger("Hit");
    Animator.SetBool("InCombat", true);
    if (Health < 1)
    {
      Destroy(gameObject);
    }
  }
}
