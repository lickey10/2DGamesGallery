using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls the in game gui
/// </summary>

public class InGameGUI : MonoBehaviour {

    //ref to the score texts
    public Text inGameScore;
    public Text gameOverScore;
    public Text hiScore;
    public string gameURL = "Link address of your game";

    //ref to background music
    public GameObject backgroundMusic;

    //ref to game over panel animator
    public Animator gameOverPanel;


    // Use this for initialization
    void Start ()
    {
        //at start we set the score to nothing
        inGameScore.text = "" + GameManager_HeadGames.instance.currentScore;

        //check for the music
        if (GameManager_HeadGames.instance.isMusicOn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //we keep updating the score each frame
        inGameScore.text = "" + GameManager_HeadGames.instance.currentScore;

        HiScore();

        //when game is over we play the game over panel animation 
        if (GameManager_HeadGames.instance.isGameOver == true)
        {
            StartCoroutine(waitGameOverPanel());

            backgroundMusic.SetActive(false);
               
        }
        else if (GameManager_HeadGames.instance.isGameOver == true)
        {
            StartCoroutine(waitGameOverPanel());

            backgroundMusic.SetActive(true);

        }

    }

    //when we press the retry button the game is started again and the score and isGame over value is reset
    public void RetryButton(string sceneName)
    {
        GameManager_HeadGames.instance.currentScore = 0;
        GameManager_HeadGames.instance.isGameOver = false;
        SceneManager.LoadScene(sceneName);
    }

    //ref to the game link
    public void RateButton()
    {
        Application.OpenURL(gameURL);
    }

    //ref to share the score on socail apps 
    public void ShareButton()
    {
        ShareScript.instance.ButtonShare();
    }

    public void HomeButton(string sceneName)
    {
        GameManager_HeadGames.instance.currentScore = 0;
        GameManager_HeadGames.instance.isGameOver = false;
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator waitGameOverPanel()
    {
        yield return new WaitForSeconds(0.6f);

        gameOverScore.text = "SCORE:" + GameManager_HeadGames.instance.currentScore;

        if (GameManager_HeadGames.instance.ringType == "twoRings")
        {
            hiScore.text = "BEST:" + GameManager_HeadGames.instance.hiScoreSimple;
        }
        else if (GameManager_HeadGames.instance.ringType == "threeRings")
        {
            hiScore.text = "BEST:" + GameManager_HeadGames.instance.hiScoreMedium;
        }
        else if (GameManager_HeadGames.instance.ringType == "fourRings")
        {
            hiScore.text = "BEST:" + GameManager_HeadGames.instance.hiScoreHell;
        }

        gameOverPanel.Play("slideIn");
        
    }

    //we save the hi-score for respective modes 
    void HiScore()
    {
        if (GameManager_HeadGames.instance.ringType == "twoRings")
        {
            //we check it the previous hiscore is less than current score and the we renew our hiscore
            if (GameManager_HeadGames.instance.hiScoreSimple < GameManager_HeadGames.instance.currentScore)
            {
                GameManager_HeadGames.instance.hiScoreSimple = GameManager_HeadGames.instance.currentScore;

                GameManager_HeadGames.instance.Save();
            }
        }
        else if (GameManager_HeadGames.instance.ringType == "threeRings")
        {
            if (GameManager_HeadGames.instance.hiScoreMedium < GameManager_HeadGames.instance.currentScore)
            {
                GameManager_HeadGames.instance.hiScoreMedium = GameManager_HeadGames.instance.currentScore;

                GameManager_HeadGames.instance.Save();
            }
        }
        else if (GameManager_HeadGames.instance.ringType == "fourRings")
        {
            if (GameManager_HeadGames.instance.hiScoreHell < GameManager_HeadGames.instance.currentScore)
            {
                GameManager_HeadGames.instance.hiScoreHell = GameManager_HeadGames.instance.currentScore;

                GameManager_HeadGames.instance.Save();
            }
        }


    }
}
