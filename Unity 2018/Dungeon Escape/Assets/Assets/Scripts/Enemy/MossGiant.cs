
using UnityEngine;

public class MossGiant : EnemyBase
{
  private Vector3 _currentTarget;
  private SpriteRenderer _spriteRenderer;
  private Animator _animator;

  public void Start()
  {
    speed = 1;
    _currentTarget = endPoint.position;
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _animator = GetComponentInChildren<Animator>();
  }

  public override void Update()
  {
    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
      return;

    

    MoveTowards();
  }

  private void MoveTowards()
  {
    if (_currentTarget == startPoint.position)
    {
      _spriteRenderer.flipX = true;
    }
    else if (_currentTarget == endPoint.position)
    {
      _spriteRenderer.flipX = false;
    }

    if (transform.position.x >= endPoint.position.x)
    {
      _currentTarget = startPoint.position;
      _animator.SetTrigger("Idle");
    }
    else if (transform.position.x <= startPoint.position.x)
    {
      _currentTarget = endPoint.position;      
      _animator.SetTrigger("Idle");
    }    

    transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);    
  }
}
