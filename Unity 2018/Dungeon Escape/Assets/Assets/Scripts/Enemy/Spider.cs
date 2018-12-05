using UnityEngine;

public class Spider : EnemyBase, IDamageable
{
  public override void Init()
  {
    base.Init();
  }

  public int Health { get; set; }

  public void Damage(int damageAmount)
  {
    Health -= damageAmount;
    if (Health <= 0)
    {

    }
  }
}
