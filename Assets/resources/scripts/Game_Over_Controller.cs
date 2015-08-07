using UnityEngine;
using System.Collections;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Game_Over_Controller : MonoBehaviour {
	
	public GameObject Play_Game_Brick;
	public GameObject And_Brick;

	public static int gameOverCount = 0;

	public static bool showAd;
	
	private Vector3 Play_Game_Brick_Starting_Location;
	private Vector3 And_Brick_Starting_Location;
	private InterstitialAd interstitial;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("goc" + gameOverCount);
		Debug.Log (Application.loadedLevel);
		Play_Game_Brick_Starting_Location = new Vector3 (10, 0, 0);
		And_Brick_Starting_Location = new Vector3 (-2, 2, 0);
		Instantiate (Play_Game_Brick, Play_Game_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		Instantiate (And_Brick, And_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		if(gameOverCount != 13) {
			gameOverCount ++;
		}
	}

	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3299124219321623/9574691991";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.AdLoaded += HandleInterstitialLoaded;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitialOpened;
		interstitial.AdClosing += HandleInterstitialClosing;
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
				.AddKeyword("game")
				.SetGender(Gender.Male)
				.SetBirthday(new DateTime(1985, 1, 1))
				.TagForChildDirectedTreatment(false)
				.AddExtra("color_bg", "9B30FF")
				.Build();
		
	}

	private void ShowInterstitial()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			print("Interstitial is not ready yet.");
		}
	}

	#region Banner callback handlers

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}

	void HandleAdClosing(object sender, EventArgs args)
	{
		print("HandleAdClosing event received");
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}

	#endregion

	#region Interstitial callback handlers

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}

	void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}

	#endregion
}