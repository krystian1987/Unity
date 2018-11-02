using Assets.Prefabs.Attackers;
using UnityEngine;

namespace Assets.Scripts
{
  public class Gravestone : MonoBehaviour
  {
    private Animator _animator;

    void Start()
    {
      _animator = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
      Attacker attacker = collider.gameObject.GetComponent<Attacker>();
      if (attacker != null)
      {
        Fox fox = collider.gameObject.GetComponent<Fox>();
        if (!fox)
        {
          _animator.SetTrigger("UnderAttackTrigger");
        }
      }
    }
  }
}
