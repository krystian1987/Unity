using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Rigidbody2D _rigidbody2D;
  private bool _isGround = false;
  private bool _resetJump = false;
  [SerializeField]
  private float _jumpForce = 5f;

  // Use this for initialization
  void Start ()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();

  }
	
	// Update is called once per frame
  void Update()
  {
    var move = Input.GetAxisRaw("Horizontal");

    if (Input.GetKeyDown(KeyCode.Space) && _isGround)
    {
      _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
      _isGround = false;
      _resetJump = true;
      StartCoroutine(ResetJumpNeedRoutine());
    }

    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
    Debug.DrawRay(transform.position,Vector3.down * 0.6f, Color.green);
    if (hitInfo.collider != null)
    {
      Debug.Log("hit " + hitInfo.collider.name);
      if (_resetJump == false)
      {
        _isGround = true;
        
      }
    }

    _rigidbody2D.velocity = new Vector2(move, _rigidbody2D.velocity.y);
    _resetJump = false;
  }

  private IEnumerator ResetJumpNeedRoutine()
  {
    yield return new WaitForSeconds(0.1f);
    _resetJump = false;
  }

  //void OnCollisionEnter2D(Collision2D col)
  //{
  //  _isGround = true;
  //}

  //void OnCollisionExit2D(Collision2D col)
  //{
  //  _isGround = false;
  //}
}
