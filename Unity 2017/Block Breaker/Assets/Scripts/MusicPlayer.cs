using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   static MusicPlayer Instance = null;

  void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      print("Duplicate music player self-destructing!");
    }
    else
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  // Use this for initialization
  void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
