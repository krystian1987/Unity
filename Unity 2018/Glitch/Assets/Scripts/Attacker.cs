using UnityEngine;

namespace Assets.Scripts
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class Attacker : MonoBehaviour
  {
    private float _currentSpeed;
    private GameObject _currentTargt;
    private Animator _animator;

    [Tooltip("Average number of seconds between appearances")]
    public float SeenEverySeconds;

    // Use this for initialization
    void Start ()
    {
      _animator = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update () {
      transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
      if (_currentTargt == null)
        _animator.SetBool("IsAttacking", false);
    }

    public void SetCurrentSpeed(float speed)
    {
      _currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
      if (_currentTargt != null)
      {
        var health = _currentTargt.GetComponent<Health>();
        if (health != null)
        {
          health.DealDamage(damage);
        }
      }
    }

    public void Attack(GameObject obj)
    {
      if (_currentTargt == null)
      {
        _currentTargt = obj;
      }
    }
  }
}
