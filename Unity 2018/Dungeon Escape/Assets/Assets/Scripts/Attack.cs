using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  private bool _canDamage = true;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    IDamageable hitObject = collider.GetComponent<IDamageable>();
    if (hitObject != null)
    {
      if (_canDamage)
      {
        hitObject.Damage(1);
        _canDamage = false;
        StartCoroutine(ResetDamage());
      }
    }
  }

  IEnumerator ResetDamage()
  {
    yield return new WaitForSeconds(0.5f);
    _canDamage = true;
  }

}
