using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : EnemyBase
{
  private Vector3 _currentTarget;
  private SpriteRenderer _spriteRenderer;

  public void Start()
  {
    speed = 1;
    _currentTarget = endPoint.position;
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }

  public override void Update()
  {
    MoveTowards();
  }

  private void MoveTowards()
  {
    if(transform.position.x >= endPoint.position.x)
    {
      _currentTarget = startPoint.position;
      _spriteRenderer.flipX = true;
    }
    else if (transform.position.x <= startPoint.position.x)
    {
      _currentTarget = endPoint.position;
      _spriteRenderer.flipX = false;
    }

    transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);    
  }
}
