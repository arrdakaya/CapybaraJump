using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RewardedAds : MonoBehaviour
{

    private RewardedAd adRewarded;
    public string AndroidRewardedAd;
    public string IosRewardedAd;
    string AdId;
    void Start()
    {
        RequestRewardedAd();
    }

    void RequestRewardedAd()
    {
#if UNITY_ANDROID
        AdId = AndroidRewardedAd;
#elif UNITY_IPHONE
        AdId = IosRewardedAd;
#else
        AdId = "Platform not recognized";
#endif

        adRewarded = new RewardedAd(AdId);

        adRewarded.OnAdLoaded += isloaded;
        adRewarded.OnAdFailedToLoad += loaderror;
        adRewarded.OnAdOpening += opened;
        adRewarded.OnAdFailedToShow += isOpen;
        adRewarded.OnUserEarnedReward += isUserWatch;
        adRewarded.OnAdClosed += closed;

        AdRequest request = new AdRequest.Builder().Build();
        adRewarded.LoadAd(request);
    }

    public void isloaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("isloaded event receiver");
    }
    public void loaderror(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("loaderror event receiver");

    }
    public void opened(object sender, EventArgs args)
    {
        MonoBehaviour.print("opened event receiver");
    }
    public void isOpen(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print("isOpen event receiver");
    }
    public void closed(object sender, EventArgs args)
    {
        MonoBehaviour.print("closed event receiver");

    }
    public void isUserWatch(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("Ödül Türü:" + type + "miktar:" + amount);
        MonoBehaviour.print("isUserWatch event receiver");
    }
    public void showRewardedAd()
    {
        if (adRewarded.IsLoaded())
        {
            adRewarded.Show();
        }
    }
}
