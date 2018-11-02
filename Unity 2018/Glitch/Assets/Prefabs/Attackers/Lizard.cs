using Assets.Scripts;
using UnityEngine;

namespace Assets.Prefabs.Attackers
{
  [RequireComponent(typeof(Attacker))]
  public class Lizard : MonoBehaviour
  {
    private Attacker _attacker;
    private Animator _animator;

// Use this for initialization
    void Start()
    {
      _animator = GetComponent<Animator>();
      _attacker = GetComponent<Attacker>();
    }

// Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
      GameObject obj = collider.gameObject;

      if (!obj.GetComponent<Defender>())
        return;

      _animator.SetBool("IsAttacking", true);
      _attacker.Attack(obj);
    }
  }
}

