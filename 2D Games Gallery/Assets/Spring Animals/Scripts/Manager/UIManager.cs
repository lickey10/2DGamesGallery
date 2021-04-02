using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public AudioClip btnClick;
    public float screenshotInterwal;
    public Image soundBtnImg;
    public Sprite soundOff, soundOn;
    public string storeLink, facebookPageLink;
    public GameObject ratePanel, mainMenuPanel, gameMenuPanel, pausePanel, gameOverPanel, rewardAdsPanel, unPausedObj;
    public Text inGameScore, gameOverScore, gameOverBestScore, inGameCoinText;

    private float currentTimePassed;
    private AudioSource audioS;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {   //if show rate is true and total games played divide by 4 , the remainder is zero the show rate panel
        if (GameManager_SpringAnimals.instance.showRate && GameManager_SpringAnimals.instance.gamesPlayed % 4 == 0)
            ratePanel.SetActive(true);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        audioS = GetComponent<AudioSource>();

        GameManager_SpringAnimals.instance.gamesPlayed++;
        GameManager_SpringAnimals.instance.isGameOver = false;
        currentTimePassed = screenshotInterwal;
        //sound button
        if (GameManager_SpringAnimals.instance.isMusicOn == true)
        {
            AudioListener.volume = 1;
            soundBtnImg.sprite = soundOff;
        }
        else
        {
            AudioListener.volume = 0;
            soundBtnImg.sprite = soundOn;
        }

        Time.timeScale = 1;
        GameManager_SpringAnimals.instance.currentScore = 0;
        GameManager_SpringAnimals.instance.currentCoins = 0;
        inGameScore.text    = "" + GameManager_SpringAnimals.instance.currentScore;
        inGameCoinText.text = "" + GameManager_SpringAnimals.instance.currentCoins;

        if (GameManager_SpringAnimals.instance.restart)
            PlayBtn();
	}

    void Update()
    {   //if game is over or game has not started we then return
        if (GameManager_SpringAnimals.instance.isGameOver == true || LevelController.instance.gameStarted == false) return;

        currentTimePassed -= Time.deltaTime;
        if (currentTimePassed <= 0)
        {
            currentTimePassed = screenshotInterwal;
            ShareScreenShot.instance.TakeScreenshot();
        }
    }
    public void ClickSound()
    {
        audioS.PlayOneShot(btnClick);
    }

#region MainMenu

    public void PlayBtn()
    {
        ClickSound();
        mainMenuPanel.SetActive(false);
        gameMenuPanel.SetActive(true);
        LevelController.instance.gameStarted = true;
        if (GameManager_SpringAnimals.instance.restart == true)
            GameManager_SpringAnimals.instance.restart = false;
    }

    public void RateBtn()
    {
        ClickSound();
        GameManager_SpringAnimals.instance.showRate = false;
        GameManager_SpringAnimals.instance.Save();
        Application.OpenURL(storeLink);
    }

    public void NoAdsBtn()
    {
        ClickSound();
        //uncomment after you import Unity IAP sdk
        //Purchaser.instance.BuyNoAds();
    }

    public void LeaderboardBtn()
    {
        ClickSound();
#if UNITY_ANDROID
        GooglePlayManager.singleton.OpenLeaderboardsScore();
#elif UNITY_IOS
        LeaderboardiOSManager.instance.ShowLeaderboard();
#endif
    }

    public void SounBtn()
    {
        if (GameManager_SpringAnimals.instance.isMusicOn == true)
        {
            GameManager_SpringAnimals.instance.isMusicOn = false;
            AudioListener.volume = 0;
            soundBtnImg.sprite = soundOn;
            GameManager_SpringAnimals.instance.Save();
        }
        else
        {
            GameManager_SpringAnimals.instance.isMusicOn = true;
            AudioListener.volume = 1;
            soundBtnImg.sprite = soundOff;
            GameManager_SpringAnimals.instance.Save();
        }
        ClickSound();

    }

    public void CloseRatePanelBtn()
    {
        ClickSound();
        ratePanel.SetActive(false);
    }

#endregion

#region GameMenu

    public void PauseBtn()
    {
        ClickSound();
        unPausedObj.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeBtn()
    {
        ClickSound();
        unPausedObj.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void HomeBtn()
    {
        ClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartBtn()
    {
        ClickSound();
        GameManager_SpringAnimals.instance.restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


#endregion

#region GameOverMenu

    public void FacebookLikeBtn()
    {
        ClickSound();
        Application.OpenURL(facebookPageLink);
    }

    public void ShareBtn()
    {
        ClickSound();
        ShareScreenShot_SpringAnimals.instance.ShareMethod();
    }

    public void RewardAdsBtn()
    {
        ClickSound();
#if UNITY_ADS
        UnityAds.instance.ShowRewardedAd();
#endif

    }

    public void CloseRewardsAdsBtn()
    {
        ClickSound();
        rewardAdsPanel.SetActive(false);
    }

#endregion

    public void GameOver()
    {
        GameManager_SpringAnimals.instance.isGameOver = true;
        GameManager_SpringAnimals.instance.lastScore = GameManager_SpringAnimals.instance.currentScore;

        gameOverScore.text = "Score: " + GameManager_SpringAnimals.instance.currentScore;

        if(GameManager_SpringAnimals.instance.currentScore > GameManager_SpringAnimals.instance.hiScore)
            GameManager_SpringAnimals.instance.hiScore = GameManager_SpringAnimals.instance.currentScore;

        gameOverBestScore.text = "Best: " + GameManager_SpringAnimals.instance.hiScore;

        gameMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        GameManager_SpringAnimals.instance.Save();

        if (UnityAds_SpringAnimals.instance.IsRewardAdsReady)
            rewardAdsPanel.SetActive(true);
    }

}
