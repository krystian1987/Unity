using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
  public Slider difficultySlider;
  public Slider volumeSlider;
  public LevelManager levelManager;

  private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start ()
	{
	  musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
	  difficultySlider.value = PlayerPrefManager.GetDifficulty();
    volumeSlider.value = PlayerPrefManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update ()
	{
	  musicPlayer.ChangeVolume(volumeSlider.value);
	}

  public void SetDefaults()
  {
    difficultySlider.value = 2f;
    volumeSlider.value = 0.5f;
  }

  public void SaveAndExit()
  {
    //PlayerPrefManager.SetUnlockedLevel();
    //PlayerPrefManager.SetDifficulty();
    PlayerPrefManager.SetDifficulty(difficultySlider.value);
    PlayerPrefManager.SetMasterVolume(volumeSlider.value);
    levelManager.LoadLevel("Start");
  }
}
