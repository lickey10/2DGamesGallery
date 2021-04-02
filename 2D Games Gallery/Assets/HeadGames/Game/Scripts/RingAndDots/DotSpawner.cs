using UnityEngine;
using System.Collections;

/// <summary>
/// This script controls the spawning of dots , object pooling is used
/// </summary>

public class DotSpawner : MonoBehaviour {

    public static DotSpawner instance;

    public Transform[] spawnPos;

    private float time;

    //for speed of dots
    public float speed;
    public float maxSpeed;
    //the milestone which tells when to increase speed
    public float speedIncreaseMilestone;
    //this is used to set new milestone when we reach one
    [HideInInspector]
    public float speedMileStoneCount;
    //amount by whihc speed is increase when we hit milestone
    public float speedMultiplier;

    private string ringType;

    private int i; //this is to choose between spawn pos (left , right)
    private int j = 0;//this is to make gameover sound play once;

    private AudioSource audioSource;
    public AudioClip[] audioClip;
    public int score;

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

        ringType = GameManager_HeadGames.instance.ringType;

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(WhenSpawnDots());

        //initially we need some milestone 
        speedMileStoneCount = speedIncreaseMilestone;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (GameManager_HeadGames.instance.isGameOver == false)
        {
            CheckMileStone();
        }

        if (GameManager_HeadGames.instance.currentScore > score)
        {
            audioSource.PlayOneShot(audioClip[0]);

            score = GameManager_HeadGames.instance.currentScore;
        }

        if (GameManager_HeadGames.instance.isGameOver == true)
        {
            if (j == 0)
            {
                audioSource.PlayOneShot(audioClip[1]);
                j++;
            }
        }
	}

    void CheckMileStone()
    {
        //if the score gets grater than milestone the speed is increased
        if (GameManager_HeadGames.instance.currentScore > speedMileStoneCount)
        {
            //when the speeed is increased we increase the milestones and set new ones
            speedMileStoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone += speedIncreaseMilestone;
            //speed is increase my multiplying with the specific number whihc you can change from inspector
            speed *= speedMultiplier;

            //if our speed goes above max speed limit then we set the speed to max speed
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
    }

    void SpawnDotsLeft()
    {
        if (ringType == "twoRings")
        {
            time = 5f / speed;
            int r = Random.Range(0, 2);
            //blue
            if (r == 0)
            {
                i = 0;
                SpawnBlueDots();
            }          
            //red
            else if (r == 1)
            {
                i = 0;
                SpawnRedDots();
            }
        }
        else if (ringType == "threeRings")
        {
            time = 5f / speed;
            int r = Random.Range(0, 3);
            //green
            if (r == 0)
            {
                i = 0;
                SpawnGreenDots();
            }
            //red
            else if (r == 1)
            {
                i = 0;
                SpawnRedDots();
            }
            //yellow
            else if (r == 2)
            {
                i = 0;
                SpawnYellowDots();
            }
        }
        else if (ringType == "fourRings")
        {
            time = 5f / 3;
            int r = Random.Range(0, 4);
            //blue
            if (r == 0)
            {
                i = 0;
                SpawnBlueDots();
            }
            //green
            else if (r == 1)
            {
                i = 0;
                SpawnGreenDots();
            }
            //red
            else if (r == 2)
            {
                i = 0;
                SpawnRedDots();
            }
            //yellow
            else if (r == 3)
            {
                i = 0;
                SpawnYellowDots();
            }
        }
    }

    void SpawnDotsRight()
    {
        time = 5f / speed;
        if (ringType == "twoRings")
        {
            time = 5f / speed;
            int r = Random.Range(0, 2);
            //blue
            if (r == 0)
            {
                i = 1;
                SpawnBlueDots();
            }
            //red
            else if (r == 1)
            {
                i = 1;
                SpawnRedDots();
            }
        }
        else if (ringType == "threeRings")
        {
            time = 5f / speed;
            int r = Random.Range(0, 3);
            //green
            if (r == 0)
            {
                i = 1;
                SpawnGreenDots();
            }
            //red
            else if (r == 1)
            {
                i = 1;
                SpawnRedDots();
            }
            //yellow
            else if (r == 2)
            {
                i = 1;
                SpawnYellowDots();
            }
        }
        else if (ringType == "fourRings")
        {
            time = 5f / 3;
            int r = Random.Range(0, 4);
            //blue
            if (r == 0)
            {
                i = 1;
                SpawnBlueDots();
            }
            //green
            else if (r == 1)
            {
                i = 1;
                SpawnGreenDots();
            }
            //red
            else if (r == 2)
            {
                i = 1;
                SpawnRedDots();
            }
            //yellow
            else if (r == 3)
            {
                i = 1;
                SpawnYellowDots();
            }
        }
    }

    IEnumerator WhenSpawnDots()
    {
        yield return new WaitForSeconds(time);

        if (GameManager_HeadGames.instance.isGameOver == false)
        {
            SpawnDotsLeft();

            SpawnDotsRight();
        }

        StartCoroutine(WhenSpawnDots());


    }

    void SpawnBlueDots()
    {
        GameObject dot = ObjectPoolerScript.instance.GetDotsBlue();

        dot.transform.position = new Vector3(spawnPos[i].position.x, transform.position.y, transform.position.z);

        dot.transform.rotation = transform.rotation;
        dot.SetActive(true);
    }

    void SpawnGreenDots()
    {
        GameObject dot = ObjectPoolerScript.instance.GetDotsGreen();

        dot.transform.position = new Vector3(spawnPos[i].position.x, transform.position.y, transform.position.z);

        dot.transform.rotation = transform.rotation;
        dot.SetActive(true);
    }

    void SpawnRedDots()
    {
        GameObject dot = ObjectPoolerScript.instance.GetDotsRed();

        dot.transform.position = new Vector3(spawnPos[i].position.x, transform.position.y, transform.position.z);

        dot.transform.rotation = transform.rotation;
        dot.SetActive(true);
    }

    void SpawnYellowDots()
    {
        GameObject dot = ObjectPoolerScript.instance.GetDotsYellow();

        dot.transform.position = new Vector3(spawnPos[i].position.x, transform.position.y, transform.position.z);

        dot.transform.rotation = transform.rotation;
        dot.SetActive(true);
    }


}
