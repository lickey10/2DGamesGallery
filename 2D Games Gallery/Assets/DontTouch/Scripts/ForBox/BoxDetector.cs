using UnityEngine;
using System.Collections;
/// <summary>
/// this script is used to detect the boxes and make the deactive
/// For more detail see ReadMe
/// </summary>
public class BoxDetector : MonoBehaviour {

    public static BoxDetector instance;

    [HideInInspector]
    public bool isGameOver;//check for game over

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.CompareTag(GameManager_DontTouch.singleton.currentBox)))
        {
            //if the tag of box is other than the instructed box , the game get over
            isGameOver = true;
        }
    }

}
