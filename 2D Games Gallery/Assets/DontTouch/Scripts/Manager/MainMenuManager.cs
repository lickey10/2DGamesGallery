using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for the working or mainMenu scene gui
/// </summary>
public class MainMenuManager : MonoBehaviour {

    public string iOSURL = "itms://itunes.apple.com/us/app/apple-store/id963781532?mt=8";
    public string ANDROIDURL = "";

    public Image soundImage;
    public Sprite[] soundSprite; // 1 is on and 0 is off

    void Start()
    {
        //sound button
        if (GameManager_DontTouch.singleton.isMusicOn == true)
        {
            AudioListener.volume = 1;
            soundImage.sprite = soundSprite[1];
        }
        else
        {
            AudioListener.volume = 0;
            soundImage.sprite = soundSprite[0];
        }
    }

    public void PlayBtn()
    {
        Application.LoadLevel("GamePlay");
    }

    public void RateBtn()
    {
#if UNITY_IPHONE
		Application.OpenURL(iOSURL);
#endif

#if UNITY_ANDROID
        Application.OpenURL(ANDROIDURL);
#endif
    }

    public void LeaderboardBtn()
    {

    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void FacebookBtn()
    {
        //uncomment after importing facebook
       // SocialManager.instance.FBShareLink();
    }

    public void SoundBtn()
    {
        if (GameManager_DontTouch.singleton.isMusicOn == true)
        {
            GameManager_DontTouch.singleton.isMusicOn = false;
            AudioListener.volume = 0;
            soundImage.sprite = soundSprite[0];
            GameManager_DontTouch.singleton.Save();
        }
        else
        {
            GameManager_DontTouch.singleton.isMusicOn = true;
            AudioListener.volume = 1;
            soundImage.sprite = soundSprite[1];
            GameManager_DontTouch.singleton.Save();
        }
    }
}
