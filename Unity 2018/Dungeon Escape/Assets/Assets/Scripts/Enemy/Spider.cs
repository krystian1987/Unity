using UnityEngine;

public class Spider : EnemyBase, IDamageable
{
  public int Health { get; set; }
  public GameObject AcidEffectPrefab;

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
      Death();
    }
  }

  public override void Update()
  {
    if (player != null)
    {
      float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
      if (distance < 10f)
      {
        Animator.SetBool("InCombat", true);
      }
      else
      {
        Animator.SetBool("InCombat", false);
      }
    }
  }

  protected override void MoveTowards()
  {
  }

  public void Attack()
  {
    Instantiate(AcidEffectPrefab, transform.position, Quaternion.identity);
  }
}
