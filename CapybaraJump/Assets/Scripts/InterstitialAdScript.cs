using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InterstitialAdScript : MonoBehaviour
{
    public static InterstitialAdScript _instance;   
    private InterstitialAd interstitialAd;
    public string AndroidInterstitialAd;
    public string IosInterstitialAd;
    string AdId;
      void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    void Start()
    {
        RequestInterstitial();
    }

    void RequestInterstitial()
    {
#if UNITY_ANDROID
        AdId = AndroidInterstitialAd;
#elif UNITY_IPHONE
        AdId = IosInterstitialAd;
    
#else
        AdId = "Platform not recognized";
#endif

        interstitialAd = new InterstitialAd(AdId);
        interstitialAd.OnAdLoaded += isloaded;
        interstitialAd.OnAdFailedToLoad += loaderror;
        interstitialAd.OnAdOpening += opened;
        interstitialAd.OnAdClosed += closed;

        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }
        public void GameOver()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            RequestInterstitial();

        }
    }
    public void isloaded(object sender,EventArgs args)
    {
        MonoBehaviour.print("isloaded event receiver");
    }
    public void loaderror(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("loaderror event receiver");
        RequestInterstitial();

    }
    public void opened(object sender, EventArgs args)
    {
        MonoBehaviour.print("opened event receiver");
    }
    public void closed(object sender, EventArgs args)
    {
        MonoBehaviour.print("closed event receiver");
        RequestInterstitial();

    }
    

}
