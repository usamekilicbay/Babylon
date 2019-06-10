using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rewarded : MonoBehaviour {

    public string appId;
    private RewardedAd rewardedAd;

    public void Start()
    {
        // Reklamı Yükler
        RequestRewardedAds();
    }
    public void RequestRewardedAds()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = appId;
#elif UNITY_IPHONE
            adUnitId = appId;
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ödüllü Reklam Yüklendi Hacı Abi...");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        Debug.Log("Ödüllü Reklam Yüklenmediyse Tekrar Yüklerim Hacı Abi...");
        //Reklam Açıldıysa Yeniden Reklam Yükler
        RequestRewardedAds();
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Ödüllü Reklam Açıldı Hacı Abi...");

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("Ödüllü Reklam Açılmıyor Hacı Abi...");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Ödüllü Reklam Kapandı Hacı Abi...");
        //Reklam Açıldıktan Sonra Yeni Reklam Yükler
        RequestRewardedAds();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("Ödüllü Reklamdan Ödül Kazandık Hacı Abi...");
    }
    public void OdulluReklamiGoster()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }

    }
}
