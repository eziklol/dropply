using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class Player : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;


    Rigidbody rb;
    public int Money;
    public GameObject MoneyText;
    public int Bank;
    public float Score;
    public float score;
    public GameObject ScoreText;
    public float RecordScore;
    public GameObject RecordScoreText;
    public float Speed = 65f;
    public float Jump = 65f;
    public bool Grounded=false;
    public float horizontalShift = 3;

    public int hp = 1;
    public int maxhp = 3;

    float horizontalAxis;
    public int jump;
    public float jumptimer;
    public int right;
    public int left;
    public int liniya;
    public int napr;
    public int dvizh;

    // <<<<<<< HEAD
    //public ShopMenu cash;

    // =======
    public float TimeZamedleniye;
    public float zamedl;

// >>>>>>> 1fff49c2340be65dcf1637b732553999c0f0bcb2

    public int save;
    // Start is called before the first frame update

    public GameObject gameOverMenu;
    public AudioSource audioData;
    public ParticleSystem explosion;

    private RewardedAd rewardedAd;
    private int resumeQuantity = 1;
    public GameObject resumeButton;

    void Start()
    {
        //audioData = GetComponent<AudioSource>();

        SwipeController.SwipeEvent += ChekInput;

        this.CreateAndLoadRewardedAd();
        Speed = 20;
        zamedl = 1;
        rb = GetComponent<Rigidbody>();
        Load();
        hp = 1;
    }
    private void Load()
    {

        string key = "record";
        string key1 = "bank";
        if (PlayerPrefs.HasKey(key))
        {
            this.RecordScore = PlayerPrefs.GetFloat(key);
        }
        if (PlayerPrefs.HasKey(key1))
        {
            this.Bank = PlayerPrefs.GetInt(key1);
        }
    }
    private void Update()
    {
        //cash.MoneyMy=Money;
        if (hp == 1) { transform.localScale = new Vector3(  0.6f, 0.6f, 0.6f); }
        if (hp == 2) { transform.localScale = new Vector3(0.75f, 0.75f, 0.75f); }
        if (hp == 3) { transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); }
        if (hp == 4) { transform.localScale = new Vector3(1.2f, 1.2f, 1.2f); }
        if (hp == 5) { transform.localScale = new Vector3(1.4f, 1.4f, 1.4f); }
        if (save == 1)
        {
            save = 0;
            string key = "record";
            string key1 = "bank";
            //string key2 = "maxhp";

            PlayerPrefs.SetFloat(key, this.RecordScore);
            PlayerPrefs.SetInt(key1, this.Bank);
            //PlayerPrefs.SetInt(key2, this.maxhp); Не нужно сохранять максимальные жизни они в каждой новой игре заново начинаются

            PlayerPrefs.Save();
        }


        
        if (hp <= 0) {
            save = 1; /*SceneManager.LoadScene("Lose", LoadSceneMode.Single);*/
            Time.timeScale = 0f;
            audioData.volume = 0.01f;
            gameOverMenu.SetActive(true);
        }
      

    }

    void ChekInput(SwipeController.SwipeType type)
    {
        if ((type == SwipeController.SwipeType.LEFT) /*(Input.GetKeyDown("left")*/ && (liniya == 1) && (napr == 0))
        {
            left = 3; napr = 1; dvizh = -1;
        }
        if ((type == SwipeController.SwipeType.LEFT) /*(Input.GetKeyDown("left")*/ && (liniya == 0) && (napr == 0))
        {
            left = 3; napr = 1; dvizh = -2;
        }
        if ((type == SwipeController.SwipeType.RIGHT) /*(Input.GetKeyDown("right")*/ && (liniya == -1) && (napr == 0))
        {
            right = 3; napr = 1; dvizh = 1;
        }
        if ((type == SwipeController.SwipeType.RIGHT) /*(Input.GetKeyDown("right")*/ && (liniya == 0) && (napr == 0))
        {
            right = 3; napr = 1; dvizh = 2;
        }
        if ((Grounded == true) && (type== SwipeController.SwipeType.UP) && rb)//прыжок на пробел
        {
            Grounded = false;
            jump = 1; rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            rb.AddForce(0, Jump, 0, ForceMode.Impulse);

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {





        

        if (right==3) { rb.velocity = new Vector3(19, rb.velocity.y , Speed); }
        if (left == 3) {  rb.velocity = new Vector3(-19, rb.velocity.y , Speed); }
        
        if (TimeZamedleniye>0) { TimeZamedleniye = TimeZamedleniye - Time.deltaTime; zamedl = 1/2f;  }
        if (TimeZamedleniye <=0) { zamedl = 1f; }
            Speed = Speed + Time.deltaTime/4;//увеличение скорости со временем
        if ((right == 0)&&(left ==0)) {  rb.velocity = new Vector3(0, rb.velocity.y, zamedl*Speed);  }//Передвижение персонажа по оси z вперед}

        score = (score + Time.deltaTime*Speed);
        Score = Mathf.Round(score);
        if (Score > RecordScore) { RecordScore = Score; }

       

    }
    void OnGUI()
    {
        MoneyText.GetComponent<TextMeshProUGUI>().text = Money.ToString();
        ScoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        RecordScoreText.GetComponent<TextMeshProUGUI>().text = RecordScore.ToString();
    }
    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Money"))
        {
          
            Money = Money + 1; Bank = Bank + 1;
            
            Destroy(col.gameObject);
        }
        if ((col.gameObject.tag == "Ground"))
        {
            Grounded = true; rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        if ((col.gameObject.tag == "Kaplya"))
        {
            if (hp < maxhp) { hp = hp + 1; }; Destroy(col.gameObject);
            Debug.Log("Health " + hp + " / " + maxhp);
        }
        if ((col.gameObject.tag == "Block"))
        {
            ParticleSystem playerExplosion = Instantiate(explosion, transform);
            hp = hp - 1; Destroy(col.gameObject);zamedl = 4;TimeZamedleniye = 0.5f;
            StartCoroutine(DestroyExplosion(playerExplosion));
        }
        if ((col.gameObject.tag == "line3"))
        {
            right = 0; napr = 0;liniya = 1;
        }
        if ((col.gameObject.tag == "line-3"))
        {
            left = 0; napr = 0;liniya = -1;
        }
        if ((dvizh == 1) || (dvizh == -1))
        {
            if ((col.gameObject.tag == "line0"))
            {
                left = 0; right = 0; napr = 0; liniya = 0;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        
       
    }

    IEnumerator DestroyExplosion(ParticleSystem explosion)
    {
        yield return new WaitForSeconds(3);
        Destroy(explosion);
    }

    public void CreateAndLoadRewardedAd()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        this.CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        if (type == "Reward")
        {
            hp = 1;
            audioData.volume = 1f;
            gameOverMenu.SetActive(false);
            resumeQuantity--;

            if (resumeQuantity == 0)
            {
                resumeButton.SetActive(false);
            }
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded() && resumeQuantity > 0)
        {
            this.rewardedAd.Show();
        }
    }
}
