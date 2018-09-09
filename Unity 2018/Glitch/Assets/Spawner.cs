using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Spawner : MonoBehaviour
{
  public GameObject[] attackerPrefabsArrayl;
  private GameObject _parent;
  
  // Update is called once per frame
  void Update () {
    foreach (var item in attackerPrefabsArrayl)
    {
      if (IsTimeToSpawn(item))
      {
        Spawn(item);
      }
    }
	}

  private bool IsTimeToSpawn(GameObject attackerGameObject)
  {
    var attacker = attackerGameObject.GetComponent<Attacker>();

    float meanSpawnDelay = attacker.seenEverySeconds;
    float spawnsPerSecond = 1 / meanSpawnDelay;

    if (Time.deltaTime >meanSpawnDelay)
    {
      Debug.LogWarning("Spwan rate capped by frame rate");
    }

    float theashold = spawnsPerSecond * Time.deltaTime/5;

    if (Random.value < theashold)
    {
      return true;
    }
    return false;
  }

  void Spawn(GameObject myGameObject)
  {
    GameObject newProjectile = Instantiate(myGameObject) as GameObject;
    newProjectile.transform.parent = transform;
    newProjectile.transform.position = transform.position;
  }
}
