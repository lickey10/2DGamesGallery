using UnityEngine;
using System.Collections;
/// <summary>
/// This script is used to spawn boxes
/// For more details see ReadMe
/// </summary>
public class BoxSpawner : MonoBehaviour {

    public static BoxSpawner instance;


    public GameObject[] boxToSpawn;//this are the positions from where boxes will spawn

    /// <summary>
    /// Below variables are for controlling box behaviours
    /// </summary>
    public float forceY; // this is to give force to box
    public float maxForceY;//max force with which boxes moves down
    public float forceMultiplier;//to increase forceY
    public float forceIncreaseMileStone;//milestone which determine when to increase forceY
    private float forceMileStoneCount;//it keep track how many time forceY is increased
    public float minTime = 1.3f;//the min time between corresponding spawning of boxes
    public float maxTime = 3f;//the max time between corresponding spawning of boxes

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }


    // Use this for initialization
    void Start ()
    {
        //here we set the values
        forceMileStoneCount = forceIncreaseMileStone;

        int j = Random.Range(0, 2); // just to spawn box at start , this chekc that all the spawner dont spawn boxes
        if (j == 1)
        {
            if (BoxDetector.instance.isGameOver == false && PlayerController_DontTouch.instance.gameOver == false)
            {
                SelectBox();
            }
        }

        StartCoroutine(WaitForNextSpawn());
	}

    //this method keep track when to spawn box
    IEnumerator WaitForNextSpawn()
    {
        //randomly choosing the time
        float timeToSpawn = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(timeToSpawn);
        int j = Random.Range(0, 2);
        if (j == 1 )
        {
            if (BoxDetector.instance.isGameOver == false && PlayerController_DontTouch.instance.gameOver == false)
            {
                SelectBox();
            }
        }
        StartCoroutine(WaitForNextSpawn());
    }

    //this method select the box to be spawn
    void SelectBox()
    {
        int i = Random.Range(0, boxToSpawn.Length);

        if (i == 0)
        {
            GameObject newElephant = ObjectPooling_DontTouch.instance.GetElephant();
            newElephant.transform.position = this.transform.position; // we spawn box at the spawner position
            newElephant.transform.rotation = this.transform.rotation;
            newElephant.SetActive(true);//we make that box active 
        }
        else if (i == 1)
        {
            GameObject newHippo = ObjectPooling_DontTouch.instance.GetHippo();
            newHippo.transform.position = this.transform.position;
            newHippo.transform.rotation = this.transform.rotation;
            newHippo.SetActive(true);
        }
        else if (i == 2)
        {
            GameObject newSnake = ObjectPooling_DontTouch.instance.GetSnake();
            newSnake.transform.position = this.transform.position;
            newSnake.transform.rotation = this.transform.rotation;
            newSnake.SetActive(true);
        }
        else if (i == 3)
        {
            GameObject newPig = ObjectPooling_DontTouch.instance.GetPig();
            newPig.transform.position = this.transform.position;
            newPig.transform.rotation = this.transform.rotation;
            newPig.SetActive(true);
        }
        else if (i == 4)
        {
            GameObject newParrot = ObjectPooling_DontTouch.instance.GetParrot();
            newParrot.transform.position = this.transform.position;
            newParrot.transform.rotation = this.transform.rotation;
            newParrot.SetActive(true);
        }
        else if (i == 5)
        {
            GameObject newGiraffe = ObjectPooling_DontTouch.instance.GetGiraffe();
            newGiraffe.transform.position = this.transform.position;
            newGiraffe.transform.rotation = this.transform.rotation;
            newGiraffe.SetActive(true);
        }
        else if (i == 6)
        {
            GameObject newPanda = ObjectPooling_DontTouch.instance.GetPanda();
            newPanda.transform.position = this.transform.position;
            newPanda.transform.rotation = this.transform.rotation;
            newPanda.SetActive(true);
        }
    }
    /// <summary>
    /// for box
    /// </summary>
    void ForceApplied()
    {
        if (GameManager_DontTouch.singleton.currentScore > forceMileStoneCount)
        {
            forceMileStoneCount += forceIncreaseMileStone;
            forceIncreaseMileStone += 5f; //well this set the new mile stone which the score
            forceY *= forceMultiplier;
            minTime = Mathf.Abs(1.3f / forceY);//time is inversely proportional to forceY (Please check documents)
            maxTime = 2.3f * minTime;
            if (forceY <= maxForceY)
            {
                forceY = maxForceY;
            }

        }

        

    }

    //we keep updating force
    void Update()
    {
        ForceApplied();
    }


}

