using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
  [SerializeField]
  protected int health;
  [SerializeField]
  protected float speed;
  [SerializeField]
  protected int gems;
  [SerializeField]
  protected Transform startPoint, endPoint;

  protected Vector3 CurrentTarget;
  protected SpriteRenderer SpriteRenderer;
  protected Animator Animator;

  protected Player player;

  protected bool IsHit = false;

  public void Start()
  {
    Init();
  }
  
  public virtual void Init()
  {
    CurrentTarget = endPoint.position;
    SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    Animator = GetComponentInChildren<Animator>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
  }

  public virtual void Update()
  {
    if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Animator.GetBool("InCombat") == false)
      return;

    MoveTowards();
  }

  protected virtual void MoveTowards()
  {
    if (CurrentTarget == startPoint.position)
    {
      SpriteRenderer.flipX = true;
    }
    else if (CurrentTarget == endPoint.position)
    {
      SpriteRenderer.flipX = false;
    }

    if (transform.position.x >= endPoint.position.x)
    {
      CurrentTarget = startPoint.position;
      Animator.SetTrigger("Idle");
    }
    else if (transform.position.x <= startPoint.position.x)
    {
      CurrentTarget = endPoint.position;
      Animator.SetTrigger("Idle");
    }

    if (IsHit == false)
    {
      transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, speed * Time.deltaTime);
    }

    float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
    if (distance > 2f)
    {
      IsHit = false;
      Animator.SetBool("InCombat", false);
    }
  }

}

