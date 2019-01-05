using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
  private Player _player;

  public void Start()
  {
    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
  }

  public void ShowRewordingAd()
  {
    Debug.Log("Test123");

    const string RewardedPlacementId = "rewardedVideo";

    if (!Advertisement.IsReady(RewardedPlacementId))
    {
      Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
      return;
    }

    var options = new ShowOptions {resultCallback = HandleShowResult};
    Advertisement.Show(RewardedPlacementId, options);

  }

  private void HandleShowResult(ShowResult result)
  {
    switch (result)
    {
      case ShowResult.Finished:
        Debug.Log("The ad was successfully shown.");
        _player.AddGems(100);
        UIManager.Instance.UpdateGemCount(_player.diamonds);
        break;
      case ShowResult.Skipped:
        Debug.Log("The ad was skipped before reaching the end.");
        break;
      case ShowResult.Failed:
        Debug.LogError("The ad failed to be shown.");
        break;
    }
  }
}


