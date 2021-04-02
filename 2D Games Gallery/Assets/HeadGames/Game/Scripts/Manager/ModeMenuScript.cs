using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls the mode menu
/// </summary>

public class ModeMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
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
	
	}

    //we set the ring type depending on the button pressed to go to the respective game mode
    public void SimpleButton(string sceneName)
    {
        GameManager_HeadGames.instance.ringType = "twoRings";

        SceneManager.LoadScene(sceneName);

    }

    public void MediumButton(string sceneName)
    {

        GameManager_HeadGames.instance.ringType = "threeRings";

        SceneManager.LoadScene(sceneName);

    }

    public void NightMareButton(string sceneName)
    {

        GameManager_HeadGames.instance.ringType = "fourRings";

        SceneManager.LoadScene(sceneName);

    }

    public void BackButton(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

}
