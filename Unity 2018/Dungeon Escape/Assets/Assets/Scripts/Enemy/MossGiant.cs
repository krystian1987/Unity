
using UnityEngine;

public class MossGiant : EnemyBase, IDamageable
{
  public override void Init()
  {
    base.Init();
  }

  public int Health { get; set; }

  public void Damage(int damageAmount)
  {
    Debug.Log("Hit " + this.name + " with damage "+ damageAmount);
    Health -= damageAmount;
    if (Health <= 0)
    {
      Destroy(gameObject);
    }
  }
}
