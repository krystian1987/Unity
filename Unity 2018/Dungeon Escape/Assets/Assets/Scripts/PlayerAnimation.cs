using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
  private Animator _animator;

  // Use this for initialization
	void Start () {
	  _animator = GetComponentInChildren<Animator>();
  }

  public void Move(float move)
  {
    _animator.SetFloat("Move", Math.Abs(move));
  }

  public void Jump(bool jumping)
  {
    _animator.SetBool("Jump", jumping);
  }
}
