using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System.Linq;
using System;

public class manuCont : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource klik;
    public GameObject mainCam, circle, delik, doorLeft, doorRight, hideLdoor,hideRdoor, modumsu,logo;
    public Button playButon, quitButon, musicButon, soundButon, themeButon,shopButon,reklamShowum;
    public Sprite darkPlay, DarkQuit, darkMusic, DarkSound, darkThemeimage,darkCircle,darkDelik,Darkdoors,darkShopButon,darkReklam;
    public Sprite play, quit, music, sound, themeimage, circleImage, delikImage, doorsImage,shopum,reklamim;

  

    public string appId = "ca-app-pub-2149079899242374~4587914442";

    public string winnerID = "ca-app-pub-2149079899242374/8265484741";

    public RewardedAd rewardedAd;
    public void gameStart()
    {
        klik.Play();
        StartCoroutine(goim());
    }
    public void cikis()
    {
        
        Application.Quit();
    }

    public void winnerShow()
    {
        rewardedAd = new RewardedAd(winnerID);

        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        // Called when an ad is shown.
       rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
    rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        AdRequest request = new AdRequest.Builder().Build();
       rewardedAd.LoadAd(request);
    }

    IEnumerator showmi()
    {

        reklamShowum.interactable = false;
        klik.Play();
        winnerShow();

        yield return new WaitForSeconds(3);
        bool durumne = true;
        if (rewardedAd.IsLoaded()&&durumne)
        {
            durumne = false;
            rewardedAd.Show();
            reklamMi = true;
        }
        yield return new WaitForSeconds(2);
        if (rewardedAd.IsLoaded() && durumne)
        {
            durumne = false;
            rewardedAd.Show();
            reklamMi = true;
        }
        else
        {
            reklamMi = true;
        }


    }
    public bool reklamMi = true;
    public void asilGosterim()
    {
        reklamMi = false;
        StartCoroutine(showmi());
    }
   

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        reklamMi = true;
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        reklamMi = true;

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        string deger = amount.ToString();
        int winnerPrice = int.Parse(deger);

        int newPrices = PlayerPrefs.GetInt("Coin") + 50;
        PlayerPrefs.SetInt("Coin", newPrices);

        reklamMi = true;
        reklamShowum.interactable = true;
    }

    public void soundOff()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {

            PlayerPrefs.SetInt("Sound", 0);


        }
        else
        {

            PlayerPrefs.SetInt("Sound", 1); ;

        }
    }
    public void musicOff()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {

            PlayerPrefs.SetInt("Music", 0);


        }
        else
        {

            PlayerPrefs.SetInt("Music", 1); ;

        }
    }

    public void darkTheme(){
        klik.Play();
        if (PlayerPrefs.GetInt("Theme") == 1)
        {
           
            PlayerPrefs.SetInt("Theme", 0);
            
            
        }
        else
        {
           
            PlayerPrefs.SetInt("Theme", 1); ;
            
        }
    }
    private void Start()
    {

        MobileAds.Initialize(appId);


        if (!PlayerPrefs.HasKey("Theme"))
        {
            PlayerPrefs.SetInt("Theme",1);
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound",1);
        }
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music",1);
        }

        if(PlayerPrefs.GetInt("Theme") == 1)
        {
            lighting();
        }
        else
        {
            dark();
        }

        if (!PlayerPrefs.HasKey("reklam"))
        {
            PlayerPrefs.SetInt("reklam", 0);
        }
        else
        {
            PlayerPrefs.SetInt("reklam", 0);
        }

    }

    public void goShop(){
        klik.Play();
        SceneManager.LoadScene(3);
    }
    public bool internet;
    private void Update()
    {


        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            internet = false;
        }
        else
        {
            internet = true;
        }

        if (internet)
        {
            reklamShowum.interactable = true;
        }
        else
        {
            reklamShowum.interactable = false;

        }
        //sa
        if (reklamMi)
        {
            reklamShowum.interactable = true;
            playButon.interactable = true;
            quitButon.interactable = true;
            shopButon.interactable = true;
        }
        else
        {
            reklamShowum.interactable = false;
            playButon.interactable = false;
            quitButon.interactable = false;
            shopButon.interactable = false;

        }


        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            modumsu.GetComponent<AudioSource>().mute = false;

            soundButon.GetComponent<Image>().color = Color.white;

        }
        else
        {


            soundButon.GetComponent<Image>().color = Color.red;
            modumsu.GetComponent<AudioSource>().mute = true;


        }
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            logo.GetComponent<AudioSource>().mute = false;
            musicButon.GetComponent<Image>().color = Color.white;

        }
        else
        {
            logo.GetComponent<AudioSource>().mute = true;
            musicButon.GetComponent<Image>().color = Color.red;


        }



        if (PlayerPrefs.GetInt("Theme") == 1)
        {
            lighting();
        }
        else
        {
            dark();

        }
    }
    void dark()
    {
        shopButon.GetComponent<Image>().sprite = darkShopButon;
        reklamShowum.GetComponent<Image>().sprite = darkReklam;
        playButon.GetComponent<Image>().sprite = darkPlay;
        quitButon.GetComponent<Image>().sprite = DarkQuit;
        musicButon.GetComponent<Image>().sprite = darkMusic;
        soundButon.GetComponent<Image>().sprite = DarkSound;
        themeButon.GetComponent<Image>().sprite = darkThemeimage;
        mainCam.GetComponent<Camera>().backgroundColor = Color.black;
        circle.GetComponent<SpriteRenderer>().sprite = darkCircle;
        delik.GetComponent<SpriteRenderer>().sprite = darkDelik;
        doorLeft.GetComponent<SpriteRenderer>().sprite = Darkdoors;
        doorRight.GetComponent<SpriteRenderer>().sprite = Darkdoors;
        hideLdoor.GetComponent<SpriteRenderer>().sprite = Darkdoors;
        hideRdoor.GetComponent<SpriteRenderer>().sprite = Darkdoors;
    }
    void lighting()
    {
        reklamShowum.GetComponent<Image>().sprite = reklamim;

        shopButon.GetComponent<Image>().sprite = shopum;
        playButon.GetComponent<Image>().sprite = play;
        quitButon.GetComponent<Image>().sprite = quit;
        musicButon.GetComponent<Image>().sprite = music;
        soundButon.GetComponent<Image>().sprite = sound;
        themeButon.GetComponent<Image>().sprite = themeimage;
        mainCam.GetComponent<Camera>().backgroundColor = Color.white;
        circle.GetComponent<SpriteRenderer>().sprite = circleImage;
        delik.GetComponent<SpriteRenderer>().sprite = delikImage;
        doorLeft.GetComponent<SpriteRenderer>().sprite = doorsImage;
        doorRight.GetComponent<SpriteRenderer>().sprite = doorsImage;
        hideLdoor.GetComponent<SpriteRenderer>().sprite = doorsImage;
        hideRdoor.GetComponent<SpriteRenderer>().sprite = doorsImage;
    }

    IEnumerator goim()
    {
        yield return new WaitForSeconds(1);

        
        SceneManager.LoadScene(2);
    }
}
