using UnityEngine;
namespace Assets.Scripts
{
  public class StartVolume : MonoBehaviour
  {
    private MusicPlayer _musicPlayer;

    // Use this for initialization
    void Start () {
      _musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
      _musicPlayer.ChangeVolume(PlayerPrefManager.GetMasterVolume());
    }
  }
}
