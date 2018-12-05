using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
  [SerializeField]
  protected int Health;
  [SerializeField]
  protected float Speed;
  [SerializeField]
  protected int Gems;
  [SerializeField]
  protected Transform StartPoint, EndPoint;

  protected Vector3 CurrentTarget;
  protected SpriteRenderer SpriteRenderer;
  protected Animator Animator;

  public void Start()
  {
    Init();
  }

  public virtual void Init()
  {
    CurrentTarget = EndPoint.position;
    SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    Animator = GetComponentInChildren<Animator>();
  }

  public virtual void Update()
  {
    if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
      return;

    MoveTowards();
  }

  protected virtual void MoveTowards()
  {
    if (CurrentTarget == StartPoint.position)
    {
      SpriteRenderer.flipX = true;
    }
    else if (CurrentTarget == EndPoint.position)
    {
      SpriteRenderer.flipX = false;
    }

    if (transform.position.x >= EndPoint.position.x)
    {
      CurrentTarget = StartPoint.position;
      Animator.SetTrigger("Idle");
    }
    else if (transform.position.x <= StartPoint.position.x)
    {
      CurrentTarget = EndPoint.position;
      Animator.SetTrigger("Idle");
    }

    transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime);
  }
}
