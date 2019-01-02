using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
  private Rigidbody2D _rigidbody2D;
  private bool _resetJump = false;
  [SerializeField]
  private float _jumpForce = 5.0f;
  [SerializeField]
  private float _playerSpeed = 10.0f;
  [SerializeField]
  public int Health { get; set; }

  public int diamonds = 0;


  private Animator _animator;
  private PlayerAnimation _playerAnimation;
  private SpriteRenderer _playerSpriteRenderer;
  private SpriteRenderer _attackSpriteRenderer;

  // Use this for initialization
  void Start ()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _playerAnimation = GetComponent<PlayerAnimation>();
    _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _attackSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
    Health = 4;
  }
	
	// Update is called once per frame
  void Update()
  {
    if (Health < 1)
      return;

    Movement();
    Attack();
  }

  private void Attack()
  {
    if (IsGrounded() && Input.GetKeyDown(KeyCode.LeftShift))
    {
      _playerAnimation.Attack();
    }
  }

  private void Movement()
  {
    var move = Input.GetAxisRaw("Horizontal");
    IsGrounded();

    if (move != 0)
      FlipPlayer(move);

    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    {
      _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
      _playerAnimation.Jump(true);
      StartCoroutine(ResetJumpNeedRoutine());
    }

    _rigidbody2D.velocity = new Vector2(move * _playerSpeed, _rigidbody2D.velocity.y);

    _playerAnimation.Move(move);  
  }

  public void AddGems(int amout)
  {
    diamonds += amout;
    UIManager.Instance.UpdateGemCountText(diamonds);
  }

  private void FlipPlayer(float move)
  {
    bool fliping = (move < 0);

    _playerSpriteRenderer.flipX = fliping;
    
    _attackSpriteRenderer.flipY = fliping;

    Vector3 newPos = _attackSpriteRenderer.transform.localPosition;
    newPos.x = Mathf.Abs(newPos.x) * (fliping ?  (-1) : 1);
    _attackSpriteRenderer.transform.localPosition = newPos;
  }

  private bool IsGrounded()
  {
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
    Debug.DrawRay(transform.position, Vector3.down, Color.green);
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

  
  public void Damage(int damageAmount)
  {
    if (Health < 1)
      return;

    Health -= damageAmount;
    UIManager.Instance.UpdateLifes(Health);
    if (Health < 1)
    {
      _playerAnimation.Death();
    }
  }
}
