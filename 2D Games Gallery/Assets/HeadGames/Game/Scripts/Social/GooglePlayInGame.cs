using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
/// <summary>
/// This script controls the leaderboard , you can add achivements code to this script 
/// </summary>
public class GooglePlayInGame : MonoBehaviour {

    public static GooglePlayInGame instance;

    //ref to the leaderboard code which you will get from google
    public string LEADERBOARDS_SCORE;

    void Awake()
    {
        MakeInstance();
    }

    //we want to make this script a singleton so that it do not get destroyed when we move from one scene to other 
    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Use this for initialization
    void Start ()
    {
        //when you integrate the google play service setting just remove the "//" from code lines
        //activate the google play services
        //PlayGamesPlatform.Activate();
        //Social.localUser.Authenticate((bool success) =>
        //{
        //    if (success)
        //    {
        //        //InitializeAchievements();
        //    }
        //});
    }

    void OnLevelWasLoaded()
    {
        //CheckIfAnyUnlockedAchievements();

        if (GameManager_HeadGames.instance.ringType == "twoRings")
        {
            ReportScore(GameManager_HeadGames.instance.hiScoreSimple);
        }
        else if (GameManager_HeadGames.instance.ringType == "threeRings")
        {
            ReportScore(GameManager_HeadGames.instance.hiScoreMedium);
        }
        else if (GameManager_HeadGames.instance.ringType == "fourRings")
        {
            ReportScore(GameManager_HeadGames.instance.hiScoreHell);
        }
    }

    //use this method for button
    public void OpenLeaderboardsScore()
    {
        //if (Social.localUser.authenticated)
        //{
        //    PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);
        //}
    }

    void ReportScore(int score)
    {
        //if (Social.localUser.authenticated)
        //{
        //    Social.ReportScore(score, LEADERBOARDS_SCORE, (bool success) => { });
        //}
    }
}
