using UnityEngine;
using System.Collections;

/// <summary>
/// This script keep track of which mode to start
/// </summary>

//ref to dots
[SerializeField]
public enum WhichDot
{
    red,
    blue,
    green,
    yellow
}


public class DotController : MonoBehaviour {

    public static DotController instance;

    public WhichDot whichDot;

    private string thisTag;

    private int score;

    public GameObject explode;


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


    // Use this for initialization
    void Start ()
    {
        score = GameManager_HeadGames.instance.currentScore;
        thisTag = gameObject.tag;


	}

    // Update is called once per frame
    void Update()
    {
        Movement();
        score = GameManager_HeadGames.instance.currentScore;

    }



    void Movement()
    {

        if (GameManager_HeadGames.instance.isGameOver == false)
        {
            if (GameManager_HeadGames.instance.ringType == "twoRings")
            {
                transform.Translate(new Vector3(0, -1, 0) * DotSpawner.instance.speed * Time.deltaTime);
            }
            else if (GameManager_HeadGames.instance.ringType == "threeRings")
            {
                transform.Translate(new Vector3(0, -1, 0) * DotSpawner.instance.speed * Time.deltaTime);
            }
            else if (GameManager_HeadGames.instance.ringType == "fourRings")
            {
                transform.Translate(new Vector3(0, -1, 0) * 3 * Time.deltaTime);
            }
        }
        else if (GameManager_HeadGames.instance.isGameOver == true)
        {
            transform.Translate(Vector3.zero);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string otherObject = other.tag;

        if (otherObject != thisTag)
        {

            GameObject exp =  Instantiate(explode);

            exp.transform.position = transform.position;

            exp.transform.rotation = transform.rotation;

            GameManager_HeadGames.instance.isGameOver = true;

            gameObject.SetActive(false);

        }
        else if (otherObject == thisTag)
        {

            score++;

            GameManager_HeadGames.instance.currentScore = score;

            gameObject.SetActive(false);
        }

    }

}
