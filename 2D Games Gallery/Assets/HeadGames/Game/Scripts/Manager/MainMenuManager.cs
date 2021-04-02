using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script manages the main menu
/// </summary>

public class MainMenuManager_HeadGames : MonoBehaviour {

    //ref to the music btn
    [SerializeField]
    private Button musicBtn;
    //ref to the music sprites
    [SerializeField]
    private Sprite[] musicBtnSprite;
    //ref to the audio source
    private AudioSource audioSource;

    //ref to the game link
    public string playStore_Url = "Type your game link address";
    //ref to the othergame link
    public string moregames_Url = "Link to other games";

    //ref to the rings
    public GameObject[] rings;
    public int speedOfRing;
    //ref to the info panel
    public GameObject infoPanel;

    // Use this for initialization
    void Start ()
    {
        //when game start we get the audio source
        audioSource = GetComponent<AudioSource>();

        //we chekc for the music on or off info and we set the music button sprite and adjust the volume
        if (GameManager_HeadGames.instance.isMusicOn)
        {
            musicBtn.image.sprite = musicBtnSprite[1];
            AudioListener.volume = 1;
        }
        else
        {
            musicBtn.image.sprite = musicBtnSprite[0];
            AudioListener.volume = 0;
        }

        //we check for info panel status and if it is active in hierarchy we deactive it
        if (infoPanel.activeInHierarchy == true)
        {
            infoPanel.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        //ring 0 is inner and ring 1 is outer
        //we rotate the rings which surrounds the play button 
        rings[0].transform.Rotate(new Vector3(0, 0, speedOfRing) * Time.deltaTime);

        rings[1].transform.Rotate(new Vector3(0, 0, -speedOfRing) * Time.deltaTime);
    }

    public void PlayButton(string selScene)
    {
        audioSource.Play();
        SceneManager.LoadScene(selScene);
    }

    public void MusicButton()
    {
        audioSource.Play();

        if (GameManager_HeadGames.instance.isMusicOn)
        {
            AudioListener.volume = 0;
            musicBtn.image.sprite = musicBtnSprite[1];
            GameManager_HeadGames.instance.isMusicOn = false;
            GameManager_HeadGames.instance.Save();
        }
        else
        {
            AudioListener.volume = 1;
            musicBtn.image.sprite = musicBtnSprite[0];
            GameManager_HeadGames.instance.isMusicOn = true;
            GameManager_HeadGames.instance.Save();
        }
    }

    public void MoreGameButton()
    {
        audioSource.Play();

        Application.OpenURL(moregames_Url);
    }

    public void InfoButton()
    {
        audioSource.Play();

        infoPanel.SetActive(true);
    }

    public void CloseInfoButton()
    {
        audioSource.Play();

        infoPanel.SetActive(false);
    }

    public void RateButton() 
    {
        audioSource.Play();

        Application.OpenURL(playStore_Url);
    }

    //use this for button to open the leaderboard if you game has it 
    public void LeaderBoardBtn()
    {
        audioSource.Play();

        GooglePlayInGame.instance.OpenLeaderboardsScore();
    }


}
