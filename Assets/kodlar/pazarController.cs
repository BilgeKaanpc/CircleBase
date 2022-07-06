using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using GoogleMobileAds.Api;
using Random = UnityEngine.Random;
[System.Serializable]


public class TopButon
{
  
    public int topID;
    public Sprite topSkin;
    public int price;
    public bool isbuyedmi;
    public bool isUsedmi;
}
[System.Serializable]

public class Circles
{
    public int circleID;
    public Sprite circleSkin;
    public int price;
    public bool isbuyedmi;
    public bool isusedmi;


}

public class pazarController : MonoBehaviour
{


    public string appId = "ca-app-pub-2149079899242374~4587914442";

    public string winnerID = "ca-app-pub-2149079899242374/8265484741";

    public RewardedAd rewardedAd;

    public AudioSource sesim;

    public bool isDarkMode = false;

    public Button leftButon,rightButon,menuButon,useButonum,buyButonum,ballsButon,circlesButon,panelCloseButon,reklamButon;
    public Text coinText,pagesText,buyPanelText,buyPanelID,title,panelCloseText,reklamText;
    public TopButon[] toplar;

    public Circles[] circlelar;
    public GameObject topPanel_1,buyPanel,buyPanelImage,mainCam;
    public Sprite[] ballSkinleri;
    public Text[] ballSkinFiyatlari;
    public Sprite[] cirlceSkinleri;
    public Text[] circleSkinFiyatlari;
    public GameObject coinpp;
    public Sprite darkLeft,darkRight,darkMenu,darkUse,darkBuy,darkCerceve,darkBallB,darkCircleB,darkCoin;
    public GameObject[] topPanelleri;
    public GameObject[] circePanelleri;

    public bool toplarmi = true;

    public int coinim;
    int circleSkinAdet = 9;
    int ballSkinAdet = 18;
    int circlePages = 1;
    int page = 1;
    int maxPage = 2;
    int picked;
    int pickedCircle;
    // Start is called before the first frame update
    void Start()
    {

        MobileAds.Initialize(appId);

        


        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            sesim.mute = true;

        }


        if (PlayerPrefs.GetInt("Theme") != 1){
            isDarkMode = true;
            mainCam.GetComponent<Camera>().backgroundColor = Color.black;
            coinpp.GetComponent<Image>().sprite = darkCoin;
            reklamButon.GetComponent<Image>().color = Color.white;
            leftButon.GetComponent<Image>().sprite = darkLeft;
            rightButon.GetComponent<Image>().sprite = darkRight;
            menuButon.GetComponent<Image>().sprite = darkMenu;
            useButonum.GetComponent<Image>().sprite = darkUse;
            buyButonum.GetComponent<Image>().sprite = darkBuy;
            ballsButon.GetComponent<Image>().sprite = darkBallB;
            circlesButon.GetComponent<Image>().sprite = darkCircleB;
            panelCloseButon.GetComponent<Image>().color = Color.white;
            panelCloseText.color = Color.black;

            reklamText.color = Color.black;

            coinText.color = Color.white;
            pagesText.color = Color.white;

            title.color = Color.white;

            for (int i = 0; i < ballSkinAdet; i++)
            {
                ballSkinFiyatlari[i].color = Color.white;
            }
            for (int i = 0; i < circleSkinAdet; i++)
            {
                circleSkinFiyatlari[i].color = Color.white;
            }




        }



        if(PlayerPrefs.HasKey("Coin")){
            coinim = PlayerPrefs.GetInt("Coin");
        }else{
            PlayerPrefs.SetInt("Coin",0);
        }
        if(PlayerPrefs.HasKey("ballSkin")){
            picked = PlayerPrefs.GetInt("ballSkin");
        }else{
            PlayerPrefs.SetInt("ballSkin",0);
        }

        if (PlayerPrefs.HasKey("circleSkin"))
        {
            pickedCircle = PlayerPrefs.GetInt("circleSkin");
        }
        else
        {
            PlayerPrefs.SetInt("circleSkin", 0);
        }


        guncelle();

        
        
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

        reklamButon.interactable = false;
        sesim.Play();
        winnerShow();


        yield return new WaitForSeconds(3);
        bool bilge = true;
        if (this.rewardedAd.IsLoaded()&&bilge)
        {
            bilge = false;
            this.rewardedAd.Show();
            reklamButonum = true;

        }
        yield return new WaitForSeconds(2);
        if (this.rewardedAd.IsLoaded() && bilge)
        {
            this.rewardedAd.Show();
            reklamButonum = true;

        }
        else
        {
            reklamButonum = true;
        }

    }
    public bool reklamButonum = true;

    public void gosterim()
    {
        reklamButonum = false;
        reklamButon.interactable = false;

        StartCoroutine(showmi());
    }

   

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        reklamButonum = true;

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        reklamButonum = true;

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
        reklamButon.interactable = true;
        reklamButonum = true;

    }


    public void skinUpdate(){
        for(int i = 0 ; i <ballSkinAdet;i++){
            if(PlayerPrefs.HasKey("ballSkin_"+i)){
                if(PlayerPrefs.GetInt("ballSkin_"+i)==1){
                toplar[i].isbuyedmi = true;
                }
                }else{
                    PlayerPrefs.SetInt("ballSkin_"+i,0);
                toplar[i].isbuyedmi = false;

                }
            }
        PlayerPrefs.SetInt("ballSkin_"+0,1);


        for (int i = 0; i < circleSkinAdet; i++)
        {
            if (PlayerPrefs.HasKey("circleSkin_" + i))
            {
                if (PlayerPrefs.GetInt("circleSkin_" + i) == 1)
                {
                    circlelar[i].isbuyedmi = true;
                }
            }
            else
            {
                PlayerPrefs.SetInt("circleSkin_" + i, 0);
                circlelar[i].isbuyedmi = false;

            }
        }
        PlayerPrefs.SetInt("circleSkin_" + 0, 1);

    }

    public void guncelle(){

        skinUpdate();

            for(int i = 0; i<ballSkinAdet;i++){
            if(i!=PlayerPrefs.GetInt("ballSkin")){
                toplar[i].isUsedmi = false;
            }else{
                toplar[i].isUsedmi = true;
            }

        }
        for (int i = 0; i < circleSkinAdet; i++)
        {
            if (i != PlayerPrefs.GetInt("circleSkin"))
            {
                circlelar[i].isusedmi = false;
            }
            else
            {
                circlelar[i].isusedmi = true;
            }

        }


        for (int i = 0; i<ballSkinAdet;i++){

            if(toplar[i].isUsedmi){
                ballSkinFiyatlari[i].text = "Picked";
            }
            else if(toplar[i].isbuyedmi){
                ballSkinFiyatlari[i].text = "Purchased";

            }
            else{
                ballSkinFiyatlari[i].text = toplar[i].price.ToString(); 
            }


        }

        for (int i = 0; i < circleSkinAdet; i++)
        {

            if (circlelar[i].isusedmi)
            {
                circleSkinFiyatlari[i].text = "Picked";
            }
            else if (circlelar[i].isbuyedmi)
            {
                circleSkinFiyatlari[i].text = "Purchased";

            }
            else
            {
                circleSkinFiyatlari[i].text = circlelar[i].price.ToString();
            }


        }
    }
    //Circle Skin Butonlari

    public void CircleButon_0()
    {
        sesim.Play();
        int index = 0;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_1()
    {
        sesim.Play();
        int index = 1;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_2()
    {
        sesim.Play();
        int index = 2;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_3()
    {
        sesim.Play();
        int index = 3;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_4()
    {
        sesim.Play();
        int index = 4;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_5()
    {
        sesim.Play();
        int index = 5;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_6()
    {
        sesim.Play();
        int index = 6;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_7()
    {
        sesim.Play();
        int index = 7;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    public void CircleButon_8()
    {
        sesim.Play();
        int index = 8;
        buying(circlelar[index].circleSkin, circlelar[index].price, circlelar[index].circleID, circlelar[index].isbuyedmi);
    }
    //Top Skin Butonlari

    public void ballButon_0(){
        sesim.Play();
        int index = 0;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_1(){
        sesim.Play();
        int index = 1;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_2(){
        sesim.Play();
        int index = 2;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_3(){
        sesim.Play();
        int index = 3;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_4(){
        sesim.Play();
        int index = 4;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_5(){
        sesim.Play();
        int index = 5;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_6(){
        sesim.Play();
        int index = 6;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_7(){
        sesim.Play();
        int index = 7;
        buying(toplar[index].topSkin,toplar[index].price,toplar[index].topID,toplar[index].isbuyedmi);
    }
    public void ballButon_8()
    {
        sesim.Play();
        int index = 8;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_9()
    {
        sesim.Play();
        int index = 9;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_10()
    {
        sesim.Play();
        int index = 10;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_11()
    {
        sesim.Play();
        int index = 11;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_12()
    {
        sesim.Play();
        int index = 12;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_13()
    {
        sesim.Play();
        int index = 13;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_14()
    {
        sesim.Play();
        int index = 14;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_15()
    {
        sesim.Play();
        int index = 15;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_16()
    {
        sesim.Play();
        int index = 16;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }
    public void ballButon_17()
    {
        sesim.Play();
        int index = 17;
        buying(toplar[index].topSkin, toplar[index].price, toplar[index].topID, toplar[index].isbuyedmi);
    }

    public void buying(Sprite skin, int prices, int id, bool isbuyed){
        
        buyPanel.gameObject.SetActive(true);
        buyPanelImage.GetComponent<Image>().sprite = skin;
        buyPanelText.text = prices.ToString();
        buyPanelID.text = id.ToString();
        if(isbuyed){
            useButonum.gameObject.SetActive(true);
            buyButonum.gameObject.SetActive(false);
        }else{
            useButonum.gameObject.SetActive(false);
            buyButonum.gameObject.SetActive(true);
        }
        

    }

    public bool internet = true;

    // Update is called once per frame
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

        if (internet)
        {
            reklamButon.interactable = true;
        }
        else
        {
            reklamButon.interactable = false;

        }

        if (reklamButonum)
        {
            
            reklamButon.interactable = true;
            leftButon.interactable = true;
            rightButon.interactable = true;
            menuButon.interactable = true;
            ballsButon.interactable = true;
            circlesButon.interactable = true;
        }
        else
        {
            reklamButon.interactable = false;
            leftButon.interactable = false;
            rightButon.interactable = false;
            menuButon.interactable = false;
            ballsButon.interactable = false;
            circlesButon.interactable = false;

        }

        if (toplarmi)
        {
            if (page == 1)
            {
                rightButon.interactable = true;
                leftButon.interactable = false;
            }
            else if (page == maxPage)
            {
                leftButon.interactable = true;
                rightButon.interactable = false;
            }
            else
            {
                leftButon.interactable = true;
                rightButon.interactable = true;
            }

            for (int i = 1; i <= maxPage; i++)
            {
                if (i != page)
                {
                    topPanelleri[i-1].gameObject.SetActive(false);

                }
                else
                {
                    topPanelleri[i-1].gameObject.SetActive(true);

                }
                
            }
            for (int i = 1; i <= circlePages; i++)
            {
                circePanelleri[i - 1].gameObject.SetActive(false);
            }


        }
        else
        {
            if (page == 1)
            {
                rightButon.interactable = false;
                leftButon.interactable = false;
            }
            else if (page == circlePages)
            {
                leftButon.interactable = false;
                rightButon.interactable = false;
            }
            else
            {
                leftButon.interactable = true;
                rightButon.interactable = true;
            }

            for (int i = 1; i <= circlePages; i++)
            {
                if (i != page)
                {
                    circePanelleri[i - 1].gameObject.SetActive(false);

                }
                else
                {
                    circePanelleri[i - 1].gameObject.SetActive(true);

                }
                

            }
            for (int i = 1; i <= maxPage; i++)
            {
                topPanelleri[i - 1].gameObject.SetActive(false);

            }
        }


        coinim = PlayerPrefs.GetInt("Coin");


        coinText.text = coinim.ToString();
        pagesText.text=page.ToString();


        
        

        guncelle();
    }



    public void pazarAnaManu()
    {
        sesim.Play();
        SceneManager.LoadScene(1);

    }
    public void rightPage()
    {
        sesim.Play();
        page++;
    }
    public void leftPage()
    {
        sesim.Play();
        page--;
    }
    public void circleMarket()
    {
        sesim.Play();
        toplarmi = false;
        page = 1;
    }
    public void ballMarket()
    {
        sesim.Play();
        toplarmi = true;
        page = 1;
    }
    public void buy(){
        sesim.Play();
        int userMoney = PlayerPrefs.GetInt("Coin");
        if(userMoney >= int.Parse(buyPanelText.text)){
            if (toplarmi)
            {
                toplar[int.Parse(buyPanelID.text)].isUsedmi = true;
                int newMoney = userMoney - int.Parse(buyPanelText.text);
                PlayerPrefs.SetInt("Coin", newMoney);
                buyPanel.gameObject.SetActive(false);
                int newSkin = int.Parse(buyPanelID.text);
                PlayerPrefs.SetInt("ballSkin", newSkin);
                PlayerPrefs.SetInt("ballSkin_" + int.Parse(buyPanelID.text), 1);
            }
            else
            {
                circlelar[int.Parse(buyPanelID.text)].isusedmi = true;
                int newMoney = userMoney - int.Parse(buyPanelText.text);
                PlayerPrefs.SetInt("Coin", newMoney);
                buyPanel.gameObject.SetActive(false);

                int newSkin = int.Parse(buyPanelID.text);
                PlayerPrefs.SetInt("circleSkin", newSkin);
                PlayerPrefs.SetInt("circleSkin_" + int.Parse(buyPanelID.text), 1);
            }



        }
        else{
            buyPanel.gameObject.SetActive(false);

            coinText.color = Color.red;
            StartCoroutine(normalColor());

        }
        guncelle();

    }
    IEnumerator normalColor(){
        yield return new WaitForSeconds(1);
        if(isDarkMode){
        coinText.color = Color.white;

        }else{
        coinText.color = Color.black;

        }
    }
    public void use(){
        sesim.Play();
        if (toplarmi)
        {
            buyPanel.gameObject.SetActive(false);
            int newSkin = int.Parse(buyPanelID.text);
            PlayerPrefs.SetInt("ballSkin", newSkin);
        }
        else
        {
            buyPanel.gameObject.SetActive(false);
            int newSkin = int.Parse(buyPanelID.text);
            PlayerPrefs.SetInt("circleSkin", newSkin);
        }
        
        guncelle();

    }

    public void closePanel()
    {
        sesim.Play();
        buyPanel.gameObject.SetActive(false);

    }



}


//Yeni skin paketi yuklemek icin;
/* toplar dizisine yeni skinleri ve degerlerini girin,
sprite dizisine yeni skinleri sirasi ile girin,
text dizisine yeni skin paketinin textlerini sirayla girin,
mevcut Paneli kopyalayip degisiklikleri yapin,

ballSkinAdet degiskenini guncelleyin
*/
