using UnityEngine;
using System.Collections;
//using UnityEngine.Advertisements;

public class UnityAds_HeadGames : MonoBehaviour {

    private int i = 0;

    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameManager_HeadGames.instance.isGameOver == true)
        {
            //we want only one ad to be shown so we put condition that when i is 0 we show ad.
            if (i == 0)
            {
                ShowAd();
                i++;
            }
        }
	}

    public void ShowAd()
    {
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show();
        //}
    }


}
