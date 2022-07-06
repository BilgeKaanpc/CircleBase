using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using GoogleMobileAds.Api;
using Random = UnityEngine.Random;
using GoogleMobileAds;
using Google.Play.Core;
using Google.Play.Review;

[System.Serializable]
public class circleSkin
{
    public Sprite circle;
    public Sprite door;


}

public class point : MonoBehaviour


{
    private ReviewManager _reviewManager;
    public bool internet = true;

    public bool gecisGeldi = true;
    private BannerView bannerim;
    private InterstitialAd gecis;

    public string appId = "ca-app-pub-2149079899242374~4587914442";
    public string reklamId = "ca-app-pub-2149079899242374/3693140338";
    public string inter = "ca-app-pub-2149079899242374/6347223837";
    public string winnerID = "ca-app-pub-2149079899242374/8265484741";
    public string ballWin = "ca-app-pub-2149079899242374/8203396257";

    public RewardedAd rewardedAd;


    public AdPosition position;

    public circleSkin[] circlelarim;

    public Text points,coinText,cointxt;
    public Text lvls;
    public Text lvlsT;
    public Text pT;
    public Text passT, failT;
    public int puanim = 0;
    public int gerekli = 1;
    public Button nextl, menum, tryin,menusu,restart,adsYes,adsNo;
    public Text goalim, goalT, adets,adsTextyes,adsTextno,ballOut,youWant;
    public GameObject cemberim, ana;
    public GameObject modemim,mainCam;
    public GameObject kapi1, kapi2, kapi3, kapi4;

    public Sprite[] ballSkins;

    public Sprite Circle, darkDelik, Darkdoors;
    public Sprite circleImage, delikImage, doorsImage,darkNext,darkTry,DarkManu,darkMenusu,darkRestart;

    public AudioSource ses;
    public int adet;
    public int coinsu;

    public int seviye;

    public GameObject top,safem,again,fail,adsPanel;
    public GameObject whereis;


    private PlayReviewInfo _playReviewInfo;

    [System.Obsolete]
    void Start()
    {
        if (!PlayerPrefs.HasKey("nasil"))
        {
            PlayerPrefs.SetInt("nasil", 1);
        }

        if(PlayerPrefs.GetInt("nasil")%5 == 0)
        {
            StartCoroutine(RequestReviews());
        }

        
        if(PlayerPrefs.GetInt("reklam") == 1)
        {
            ReklamlarimiGoster();
        }

        if(PlayerPrefs.HasKey("Coin")){
            coinsu = PlayerPrefs.GetInt("Coin");
        }else{
            PlayerPrefs.SetInt("Coin",0);
        }


        if(PlayerPrefs.GetInt("Music") == 1)
        {
            modemim.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            modemim.GetComponent<AudioSource>().mute = true;

        }
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            top.GetComponent<AudioSource>().mute = false;
            safem.GetComponent<AudioSource>().mute = false;
            ses.mute = false;
            again.GetComponent<AudioSource>().mute = false;
            fail.GetComponent<AudioSource>().mute = false;

        }
        else
        {
            safem.GetComponent<AudioSource>().mute = true;
            top.GetComponent<AudioSource>().mute = true;
            ses.mute = true;
            fail.GetComponent<AudioSource>().mute = true;
            again.GetComponent<AudioSource>().mute = true;


        }


        if (PlayerPrefs.GetInt("Theme") == 1)
        {

        }
        else
        {
            adsNo.GetComponent<Image>().color = Color.white;
            adsYes.GetComponent<Image>().color = Color.white;
            adsTextno.color = Color.white;
            adsTextyes.color = Color.white;
            
            cemberim.GetComponent<SpriteRenderer>().sprite = Circle;
            nextl.GetComponent<Image>().sprite = darkNext;
            menum.GetComponent<Image>().sprite = DarkManu;
            tryin.GetComponent<Image>().sprite = darkTry;
            whereis.GetComponent<SpriteRenderer>().sprite = darkDelik;
            kapi1.GetComponent<SpriteRenderer>().sprite = Darkdoors;
            kapi2.GetComponent<SpriteRenderer>().sprite = Darkdoors;
            kapi3.GetComponent<SpriteRenderer>().sprite = Darkdoors;
            kapi4.GetComponent<SpriteRenderer>().sprite = Darkdoors;
            points.color = Color.white;
            lvls.color = Color.white;
            lvlsT.color = Color.white;
            pT.color = Color.white;
            passT.color = Color.white;
            failT.color = Color.white;
            goalim.color = Color.white;
            goalT.color = Color.white;
            coinText.color = Color.white;
            cointxt.color = Color.white;
            mainCam.GetComponent<Camera>().backgroundColor = Color.black;
            adets.color = Color.white;
            menusu.GetComponent<Image>().sprite = darkMenusu;
            restart.GetComponent<Image>().sprite = darkRestart;



        }

       
        MobileAds.Initialize(appId);
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            internet = false;
        }
        else
        {
            internet = true;
        }

        winnerShow();
       
        if (PlayerPrefs.HasKey("best"))
        {
            seviye = PlayerPrefs.GetInt("best");
        }
        else
        {
            seviye = 1;
            PlayerPrefs.SetInt("best", seviye);
        }
        int skin;


        //Top skinleri kismi
        if(PlayerPrefs.HasKey("ballSkin")){
            skin = PlayerPrefs.GetInt("ballSkin");
            top.GetComponent<SpriteRenderer>().sprite = ballSkins[skin];
        }else{
            PlayerPrefs.SetInt("ballSkin",0);
            skin = 0;
            top.GetComponent<SpriteRenderer>().sprite = ballSkins[skin];

        }

        int circleSkinim;

        if (PlayerPrefs.HasKey("circleSkin"))
        {
            circleSkinim = PlayerPrefs.GetInt("circleSkin");
            cemberim.GetComponent<SpriteRenderer>().sprite = circlelarim[circleSkinim].circle;
            kapi1.GetComponent<SpriteRenderer>().sprite = circlelarim[circleSkinim].door;
            kapi2.GetComponent<SpriteRenderer>().sprite = circlelarim[circleSkinim].door;
            kapi3.GetComponent<SpriteRenderer>().sprite = circlelarim[circleSkinim].door;
            kapi4.GetComponent<SpriteRenderer>().sprite = circlelarim[circleSkinim].door;
            if (circleSkinim == 0)
            {
                if(PlayerPrefs.GetInt("Theme") != 1)
                {
                    cemberim.GetComponent<SpriteRenderer>().sprite = Circle;
                    kapi1.GetComponent<SpriteRenderer>().sprite = Darkdoors;
                    kapi2.GetComponent<SpriteRenderer>().sprite = Darkdoors;
                    kapi3.GetComponent<SpriteRenderer>().sprite = Darkdoors;
                    kapi4.GetComponent<SpriteRenderer>().sprite = Darkdoors;

                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("circleSkin", 0);
        }

        
        lvls.text = seviye +"";

        if (seviye == 1)
        {
            
            modemim.GetComponent<mod>().hiz = 50;
            gerekli = 2;
            adet = 10;
        }
        if (seviye == 2)
        {
            
            modemim.GetComponent<mod>().hiz = 51;
            gerekli = 3;
            adet = 10;
        }
        if (seviye == 3)
        {
            modemim.GetComponent<mod>().hiz = 51;
            gerekli = 4;
            adet = 10;
        }
        if (seviye == 4)
        {
            modemim.GetComponent<mod>().hiz = 51;
            gerekli = 5;
            adet = 10;
        }
        if (seviye == 5)
        {
            modemim.GetComponent<mod>().hiz = 50;
            gerekli = 6;
            adet = 10;
        }
        if (seviye == 6)
        {
            modemim.GetComponent<mod>().hiz = 75;
            gerekli = 3;
            adet = 10;
        }
        if (seviye == 7)
        {
            modemim.GetComponent<mod>().hiz = 75;
            gerekli = 4;
            adet = 10;
        }
        if (seviye == 8)
        {
            modemim.GetComponent<mod>().hiz = 75;
            gerekli = 5;
            adet = 10;
        }
        if (seviye == 9)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 3;
            adet = 10;
        }
        if (seviye == 10)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 4;
            adet = 10;
        }
        if (seviye == 11)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 5;
            adet = 10;
        }
        if (seviye == 12)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 6;
            adet = 10;
        }
        if (seviye == 13)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 7;
            adet = 10;
        }
        if (seviye == 14)
        {
            modemim.GetComponent<mod>().hiz = 100;
            gerekli = 8;
            adet = 10;
        }
        if (seviye == 15)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 4;
            adet = 10;
        }
        if (seviye == 16)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 5;
            adet = 10;
        }
        if (seviye == 17)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 6;
            adet = 10;
        }
        if (seviye == 18)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 7;
            adet = 10;
        }
        if (seviye == 19)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 8;
            adet = 10;
        }
        if (seviye == 20)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 9;
            adet = 10;
        }
        if (seviye == 21)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 10;
            adet = 10;
        }
        if (seviye == 22)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 8;
            adet = 20;
        }
        if (seviye == 23)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 10;
            adet = 20;
        }
        if (seviye == 24)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 12;
            adet = 20;
        }
        if (seviye == 25)
        {
            modemim.GetComponent<mod>().hiz = 150;
            gerekli = 15;
            adet = 20;
        }
        if (seviye == 26)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 5;
            adet = 20;
        }
        if (seviye == 27)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 6;
            adet = 20;
        }
        if (seviye == 28)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 8;
            adet = 20;
        }
        if (seviye == 29)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 10;
            adet = 20;
        }
        if (seviye == 30)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 12;
            adet = 20;
        }
        if (seviye == 31)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 14;
            adet = 20;
        }
        if (seviye == 32)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 16;
            adet = 20;
        }
        if (seviye == 33)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 4;
            adet = 5;
        }
        if (seviye == 34)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 5;
            adet = 6;
        }
        if (seviye == 35)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 6;
            adet = 7;
        }
        if (seviye == 36)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 7;
            adet = 8;
        }
        if (seviye == 37)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 8;
            adet = 9;
        }
        if (seviye == 38)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 9;
            adet = 10;
        }
        if (seviye == 39)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 5;
            adet = 5;
        }
        if (seviye == 40)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 6;
            adet = 6;
        }
        if (seviye == 41)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 7;
            adet = 7;
        }
        if (seviye == 42)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 8;
            adet = 8;
        }
        if (seviye == 43)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 9;
            adet = 9;
        }
        if (seviye == 44)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 10;
            adet = 10;
        }
        if (seviye == 45)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 11;
            adet = 12;
        }
        if (seviye == 46)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 12;
            adet = 14;
        }
        if (seviye == 47)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 14;
            adet = 16;
        }
        if (seviye == 48)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 16;
            adet = 18;
        }
        if (seviye == 49)
        {
            modemim.GetComponent<mod>().hiz = 200;
            gerekli = 18;
            adet = 20;
        }
        if (seviye == 50)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 8;
            adet = 20;
        }
        if (seviye == 51)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 10;
            adet = 20;
        }
        if (seviye == 52)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 12;
            adet = 20;
        }
        if (seviye == 53)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 14;
            adet = 20;
        }
        if (seviye == 54)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 16;
            adet = 20;
        }
        if (seviye == 55)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 9;
            adet = 10;
        }
        if (seviye == 56)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 10;
            adet = 11;
        }
        if (seviye == 57)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 11;
            adet = 12;
        }
        if (seviye == 58)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 12;
            adet = 13;
        }
        if (seviye == 59)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 13;
            adet = 14;
        }
        if (seviye == 60)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 14;
            adet = 15;
        }
        if (seviye == 61)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 15;
            adet = 16;
        }
        if (seviye == 62)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 16;
            adet = 17;
        }
        if (seviye == 63)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 17;
            adet = 18;
        }
        if (seviye == 64)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 18;
            adet = 19;
        }
        if (seviye == 65)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 19;
            adet = 20;
        }
        if (seviye == 66)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 10;
            adet = 10;
        }
        if (seviye == 67)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 11;
            adet = 11;
        }
        if (seviye == 68)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 12;
            adet = 12;
        }
        if (seviye == 69)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 13;
            adet = 13;
        }
        if (seviye == 70)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 14;
            adet = 14;
        }
        if (seviye == 71)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 15;
            adet = 15;
        }
        if (seviye == 72)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 16;
            adet = 16;
        }
        if (seviye == 73)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 17;
            adet = 17;
        }
        if (seviye == 74)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 18;
            adet = 18;
        }
        if (seviye == 75)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 19;
            adet = 19;
        }
        if (seviye == 76)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 20;
            adet = 20;
        }
        if (seviye == 77)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 21;
            adet = 21;
        }
        if (seviye == 78)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 22;
            adet = 22;
        }
        if (seviye == 79)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 23;
            adet = 23;
        }
        if (seviye == 80)
        {
            modemim.GetComponent<mod>().hiz = 250;
            gerekli = 24;
            adet = 24;
        }
        if (seviye == 81)
        {
            modemim.GetComponent<mod>().hiz = 300;
            gerekli = 15;
            adet = 30;
        }
        if (seviye == 82)
        {
            modemim.GetComponent<mod>().hiz = 300;
            gerekli = 20;
            adet = 30;
        }
        if (seviye == 83)
        {
            modemim.GetComponent<mod>().hiz = 300;
            gerekli = 25;
            adet = 30;
        }
        if (seviye == 84)
        {
            modemim.GetComponent<mod>().hiz = 300;
            gerekli = 30;
            adet = 30;
        }
        if (seviye == 85)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 5;
            adet = 30;
        }
        if (seviye == 86)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 10;
            adet = 30;
        }
        if (seviye == 87)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 15;
            adet = 30;
        }
        if (seviye == 88)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 20;
            adet = 30;
        }
        if (seviye == 89)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 25;
            adet = 30;
        }
        if (seviye == 90)
        {
            modemim.GetComponent<mod>().hiz = 350;
            gerekli = 30;
            adet = 30;
        }
        if (seviye == 91)
        {
            modemim.GetComponent<mod>().hiz = 400;
            gerekli = 10;
            adet = 10;
        }
        if (seviye == 92)
        {
            modemim.GetComponent<mod>().hiz = 400;
            gerekli = 15;
            adet = 15;
        }
        if (seviye == 93)
        {
            modemim.GetComponent<mod>().hiz = 400;
            gerekli = 20;
            adet = 20;
        }
        if (seviye == 94)
        {
            modemim.GetComponent<mod>().hiz = 400;
            gerekli = 25;
            adet = 25;
        }
        if (seviye == 95)
        {
            modemim.GetComponent<mod>().hiz = 400;
            gerekli = 30;
            adet = 30;
        }
        if (seviye == 96)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 10;
            adet = 10;
        }
        if (seviye == 97)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 15;
            adet = 15;
        }
        if (seviye == 98)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 20;
            adet = 20;
        }
        if (seviye == 99)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 25;
            adet = 25;
        }
        if (seviye == 100)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 30;
            adet = 30;
        }
        if(seviye>100)
        {
            modemim.GetComponent<mod>().hiz = 450;
            gerekli = 30;
            adet = 30;
        }



        adets.text = adet.ToString();
        goalim.text = gerekli.ToString();

    }

    IEnumerator RequestReviews()
    {
        _reviewManager = new ReviewManager();

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            Debug.Log(requestFlowOperation.Error.ToString());
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            Debug.Log(requestFlowOperation.Error.ToString());
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }

        PlayerPrefs.SetInt("nasil", PlayerPrefs.GetInt("nasil")+1);
    }


    public void bannerShow()
    {
        bannerim = new BannerView(reklamId, AdSize.Banner, position);

        AdRequest yeniReklam = new AdRequest.Builder().Build();

        bannerim.LoadAd(yeniReklam);
        bannerim.Show();
        
    }


    public void winnerShow()
    {
        this.rewardedAd = new RewardedAd(winnerID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }
    IEnumerator showmi()
    {
       


        yield return new WaitForSeconds(2);
        bool gelbe = true;
        if (this.rewardedAd.IsLoaded() && gelbe)
        {
            this.rewardedAd.Show();
            gelbe = false;
            getirAq();
        }

        yield return new WaitForSeconds(1);

        if (this.rewardedAd.IsLoaded() && gelbe)
        {
            this.rewardedAd.Show();
            gelbe = false;
            getirAq();
        }
        yield return new WaitForSeconds(1);

        if (this.rewardedAd.IsLoaded() && gelbe)
        {
            this.rewardedAd.Show();
            gelbe = false;
            getirAq();
        }
        else
        {
            getirAq();
        } 
    }

    


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        modemim.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        adets.gameObject.SetActive(false);
        goalim.gameObject.SetActive(false);
        goalT.gameObject.SetActive(false);
        lvls.gameObject.SetActive(false);
        lvlsT.gameObject.SetActive(false);
        pT.gameObject.SetActive(false);
        cemberim.gameObject.SetActive(false);
        ana.gameObject.SetActive(false);
        menusu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
        cointxt.gameObject.SetActive(false);

        failT.gameObject.SetActive(false);

        tryin.gameObject.SetActive(false);
        menum.gameObject.SetActive(false);
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        adsPanel.gameObject.SetActive(false);

        cemberim.gameObject.SetActive(true);
    }

    public void goPlayStore()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.WinnieSoft.CircleBase");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        string deger = amount.ToString();
        int winnerPrice = int.Parse(deger);
        adet = 5;
        adsPanel.gameObject.SetActive(false);
        modemim.gameObject.SetActive(true);

        points.gameObject.SetActive(true);
        adets.gameObject.SetActive(true);
        goalim.gameObject.SetActive(true);
        goalT.gameObject.SetActive(true);
        lvls.gameObject.SetActive(true);
        lvlsT.gameObject.SetActive(true);
        menusu.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        pT.gameObject.SetActive(true);
        ana.gameObject.SetActive(true);

        coinText.gameObject.SetActive(true);
        cointxt.gameObject.SetActive(true);

        failT.gameObject.SetActive(false);

        tryin.gameObject.SetActive(false);
        menum.gameObject.SetActive(false);
        adsNo.interactable = true;
        adsYes.interactable = true;


    }


    public bool bannergelsin = true;

    public void gecisReklam()
    {
        gecis = new InterstitialAd(inter);
        gecis.OnAdClosed += HandleOnAdClosed;
        AdRequest yenigecis = new AdRequest.Builder().Build();
        gecis.LoadAd(yenigecis);
        
    }
    public bool baslasinmi = true;
    IEnumerator gecisShow()
    {

        baslasinmi = false;

        bannergelsin = false;
        modemim.gameObject.SetActive(false);

        gecisGeldi = false;
        yield return new WaitForSeconds(2);
        bool vayaq = true;
        safem.gameObject.SetActive(true);

        if (gecis.IsLoaded() && vayaq)
        {
            vayaq = false;
            gecis.Show();
            getirAq();
        }

        yield return new WaitForSeconds(1);
        if (gecis.IsLoaded() && vayaq)
        {
            vayaq = false;
            gecis.Show();
            getirAq();
        }

        yield return new WaitForSeconds(1);
        if (gecis.IsLoaded() && vayaq)
        {
            vayaq = false;
            gecis.Show();
            getirAq();
        }
        else
        {
            getirAq();
            baslasinmi = true;

        }
    }

    public void getirAq()
    {
        baslasinmi = true;

        modemim.gameObject.SetActive(true);

        points.gameObject.SetActive(true);
        adets.gameObject.SetActive(true);
        goalim.gameObject.SetActive(true);
        goalT.gameObject.SetActive(true);
        lvls.gameObject.SetActive(true);
        lvlsT.gameObject.SetActive(true);
        menusu.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        pT.gameObject.SetActive(true);
        cemberim.gameObject.SetActive(true);
        ana.gameObject.SetActive(true);

        coinText.gameObject.SetActive(true);
        cointxt.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(1);
        

    }
    public bool geldiMiHic = true;
    IEnumerator wantReklam()
    {

        yield return new WaitForSeconds(2);
        adsPanel.gameObject.SetActive(true);
        geldiMiHic = false;
        nolurGel = false;
    }

    public void reklamYes()
    {

        adsNo.interactable = false;
        adsYes.interactable = false;
        StartCoroutine(showmi());
        adsPanel.gameObject.SetActive(false);
        geldiMiHic = true;
        StartCoroutine(bugra());
        failT.gameObject.SetActive(false);

        tryin.gameObject.SetActive(false);
        menum.gameObject.SetActive(false);

    }

    public void reklamNo()
    {
        adsPanel.gameObject.SetActive(false);
        geldiMiHic = true;
        menusu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        adets.gameObject.SetActive(false);
        goalim.gameObject.SetActive(false);
        goalT.gameObject.SetActive(false);
        lvls.gameObject.SetActive(false);
        lvlsT.gameObject.SetActive(false);
        pT.gameObject.SetActive(false);
        cemberim.gameObject.SetActive(false);
        ana.gameObject.SetActive(false);
        failT.gameObject.SetActive(true);

        tryin.gameObject.SetActive(true);
        menum.gameObject.SetActive(true);

        coinText.gameObject.SetActive(false);
        cointxt.gameObject.SetActive(false);

    }

    public void HandleOnAdClosed(object sender, EventArgs args)

    {
        bannerShow();

        baslasinmi = true;
        modemim.gameObject.SetActive(true);

        points.gameObject.SetActive(true);
        adets.gameObject.SetActive(true);
        goalim.gameObject.SetActive(true);
        goalT.gameObject.SetActive(true);
        lvls.gameObject.SetActive(true);
        lvlsT.gameObject.SetActive(true);
        menusu.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        pT.gameObject.SetActive(true);
        cemberim.gameObject.SetActive(true);
        ana.gameObject.SetActive(true);

        coinText.gameObject.SetActive(true);
        cointxt.gameObject.SetActive(true);
    }
    void Update()
    {

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            internet = false;
        }
        else
        {
            internet = true;
        }

        points.text = puanim + "";
        
       coinText.text = coinsu.ToString();
        PlayerPrefs.SetInt("Coin",coinsu);
       
        
        adets.text = adet.ToString();
        if (puanim == gerekli)
        {


            PlayerPrefs.SetInt("Coin",coinsu);
            StartCoroutine(nextLevel());
            
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (adet > 0)
            {
                if (baslasinmi)
                {

                    adet--;
                    topFirlat();
                }
            }
            
        }



        if (adet <= 0)
        {
            PlayerPrefs.SetInt("Coin",coinsu);
            if (internet)
            {
                if (nolurGel)
                {
                    nolurGel = false;
                    StartCoroutine(wantReklam());




                }
                else
                {
                    StartCoroutine(controlum());
                }
                
                
            }
            else
            {
                StartCoroutine(gameOver());
            }
        }
        
    }

    IEnumerator bugra()
    {
        yield return new WaitForSeconds(4);
        if (adsPanel.gameObject.active)
        {
            goNext();
        }
        
    }

    IEnumerator controlum()

    {
        yield return new WaitForSeconds(3);
        if (adsPanel.gameObject.active)
        {
           


        }
        else
        {
          

            StartCoroutine(gameOver());
        }
    }

    public bool nolurGel = true;
    void rastgeleReklam()
    {
         int sayim = Random.Range(4,7);
        if (sayim == 5)
        {
            gecisReklam();
            StartCoroutine(gecisShow());

        }
    }

    void OnTriggerEnter2D(Collider2D diger)
    {
        if (diger.CompareTag("tops"))
        {
            coinsu++;
            puanim++;
            ses.Play();
            if (puanim == gerekli)
            {

                if(seviye == PlayerPrefs.GetInt("best"))
                {

                    PlayerPrefs.SetInt("best", seviye+1);
                }
            }

        }
    
    
    }

    void OnTriggerExit2D(Collider2D diger)
    {
        if (diger.CompareTag("tops"))
        {
            
            puanim--;
            
        }
    }
    public void topFirlat()
    {
        
         
        Instantiate(top, whereis.transform.position, whereis.transform.rotation);
    }

    IEnumerator nextLevel()
    {
        
        yield return new WaitForSeconds(1);
        
        
        points.gameObject.SetActive(false);
        adets.gameObject.SetActive(false);
        goalim.gameObject.SetActive(false);
        goalT.gameObject.SetActive(false);
        lvls.gameObject.SetActive(false);
        lvlsT.gameObject.SetActive(false);
        pT.gameObject.SetActive(false);
        cemberim.gameObject.SetActive(false);
        ana.gameObject.SetActive(false);
        passT.gameObject.SetActive(true);
        nextl.gameObject.SetActive(true);
        menum.gameObject.SetActive(true);
        menusu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
        cointxt.gameObject.SetActive(false);

    }

    

    IEnumerator gameOver()
    {
        
        yield return new WaitForSeconds(2);
        menusu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        adets.gameObject.SetActive(false);
        goalim.gameObject.SetActive(false);
        goalT.gameObject.SetActive(false);
        lvls.gameObject.SetActive(false);
        lvlsT.gameObject.SetActive(false);
        pT.gameObject.SetActive(false);
        cemberim.gameObject.SetActive(false);
        ana.gameObject.SetActive(false);
        failT.gameObject.SetActive(true);

        tryin.gameObject.SetActive(true);
        menum.gameObject.SetActive(true);

        coinText.gameObject.SetActive(false);
        cointxt.gameObject.SetActive(false);


    }


    public void ReklamlarimiGoster()
    {

        if (internet)
        {
            rastgeleReklam();
            if (bannergelsin)
            {
                bannerShow();
            }
        }

    }

    public void goNext()
    {
        
        PlayerPrefs.SetInt("reklam", 1);
        SceneManager.LoadScene(2);
    }
    public void goMenu()
    {
        SceneManager.LoadScene(1);
       
    }
}
