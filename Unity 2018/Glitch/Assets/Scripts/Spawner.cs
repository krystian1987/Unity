using Assets.Scripts;
using UnityEngine;

namespace Assets
{
  public class Spawner : MonoBehaviour
  {
    public GameObject[] AttackerPrefabsArrayl;
    private GameObject _parent;
  
    // Update is called once per frame
    void Update () {
      foreach (var item in AttackerPrefabsArrayl)
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

      float meanSpawnDelay = attacker.SeenEverySeconds;
      float spawnsPerSecond = 1 / meanSpawnDelay;

      if (Time.deltaTime >meanSpawnDelay)
      {
        Debug.LogWarning("Spawn rate capped by frame rate");
      }

      float theashold = spawnsPerSecond * Time.deltaTime / 5;

      return Random.value < theashold;
    }

    void Spawn(GameObject myGameObject)
    {
      GameObject newProjectile = Instantiate(myGameObject);
      newProjectile.transform.parent = transform;
      newProjectile.transform.position = transform.position;
    }
  }
}
