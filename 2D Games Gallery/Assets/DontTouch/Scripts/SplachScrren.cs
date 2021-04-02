using UnityEngine;
using System.Collections;

public class SplachScrren : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SplashScreen());
	}

    //this method is use to change scene from splashScreen to Main Menu
    IEnumerator SplashScreen()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("MainMenu");
    }
}
