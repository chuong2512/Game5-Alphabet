using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateApp : MonoBehaviour
{
    public void RateGame()
    {
#if UNITY_ANDROID
        Application.OpenURL(string.Format("market://details?id=" + Application.identifier));
#elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/" + Application.identifier);
#endif
        GameDataManager.Instance.playerData.Rated();
    }
}