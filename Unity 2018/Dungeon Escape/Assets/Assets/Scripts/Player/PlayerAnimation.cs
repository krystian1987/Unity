using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
  private Animator _animator;
  private Animator _swordAnim;

  // Use this for initialization
	void Start () {
	  _animator = GetComponentInChildren<Animator>();
    _swordAnim = transform.GetChild(1).GetComponent<Animator>();
  }

  public void Move(float move)
  {
    _animator.SetFloat("Move", Math.Abs(move));
  }

  public void Jump(bool jumping)
  {
    _animator.SetBool("Jump", jumping);
  }

  public void Attack()
  {
    _animator.SetTrigger("Attack");
    _swordAnim.SetTrigger("SwordAnim");
  }
}
