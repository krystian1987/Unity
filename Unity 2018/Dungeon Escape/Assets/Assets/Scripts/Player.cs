using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Rigidbody2D _rigidbody2D;
  private bool _resetJump = false;
  [SerializeField]
  private float _jumpForce = 5.0f;
  [SerializeField]
  private float _playerSpeed = 10.0f;

  private Animator _animator;
  private PlayerAnimation _playerAnimation;
  private SpriteRenderer _playerSpriteRenderer;

  // Use this for initialization
  void Start ()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _playerAnimation = GetComponent<PlayerAnimation>();
    _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }
	
	// Update is called once per frame
  void Update()
  {
    Movement();
  }

  private void Movement()
  {
    var move = Input.GetAxisRaw("Horizontal");
    IsGrounded();

    if (move != 0)
      _playerSpriteRenderer.flipX = (move < 0);

    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    {
      _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
      _playerAnimation.Jump(true);
      StartCoroutine(ResetJumpNeedRoutine());
    }

    _rigidbody2D.velocity = new Vector2(move * _playerSpeed, _rigidbody2D.velocity.y);

    _playerAnimation.Move(move);

  }

  private bool IsGrounded()
  {
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
    if (hitInfo.collider != null)
    {
      if (_resetJump == false)
      {
        _playerAnimation.Jump(false);
        return true;
      }
    }
    return false;
  }

  private IEnumerator ResetJumpNeedRoutine()
  {
    _resetJump = true;
    yield return new WaitForSeconds(0.1f);
    _resetJump = false;
  }
}
