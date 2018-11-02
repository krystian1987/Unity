using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
  public class GameTimer : MonoBehaviour
  {
    private Slider _slider;
    private AudioSource _audioSource;
    private LevelManager _levelManager;
    public float LevelSeconds = 300;
    private bool _isEndOfLevel = false;
    private GameObject _winLabel;

    // Use this for initialization
    void Start ()
    {
      _winLabel = GameObject.Find("WinText");
      _winLabel.SetActive(false);
      _slider = GetComponent<Slider>();
      _audioSource = GetComponent<AudioSource>();
      _levelManager = FindObjectOfType<LevelManager>();
    }
	
    // Update is called once per frame
    void Update ()
    {
      _slider.value = Time.timeSinceLevelLoad / LevelSeconds;
      if (_slider.value >= 1 && !_isEndOfLevel)
      {
        OnWin();
      }
    }

    private void OnWin()
    {
      DestroyOnTaggedObjects();
      _audioSource.Play();
      _winLabel.SetActive(true);
      Invoke("LoadNextLevel", _audioSource.clip.length);
      _isEndOfLevel = true;
    }

    private void DestroyOnTaggedObjects()
    {
      var allGameObjectsWithTag = GameObject.FindGameObjectsWithTag("DestroyOnWin");

      foreach (var item in allGameObjectsWithTag)
      {
        Destroy(item);
      }
    }

    //DestroyOnWin

    private void LoadNextLevel()
    {
      _levelManager.LoadNextLevel();
    }
  }
}
