using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
  [SerializeField]
  protected int health;
  [SerializeField]
  protected int speed;
  [SerializeField]
  protected int gems;
  [SerializeField]
  protected Transform startPoint, endPoint;


  public virtual void Attack()
  {

  }

  public abstract void Update();
}
