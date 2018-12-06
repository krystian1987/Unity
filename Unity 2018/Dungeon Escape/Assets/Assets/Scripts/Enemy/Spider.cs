using UnityEngine;

public class Spider : EnemyBase, IDamageable
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
    IsHit = true;
    Animator.SetTrigger("Hit");
    Animator.SetBool("InCombat", true);
    if (Health < 1)
    {
      Destroy(gameObject);
    }
  }

  protected override void MoveTowards()
  {
  }
}
