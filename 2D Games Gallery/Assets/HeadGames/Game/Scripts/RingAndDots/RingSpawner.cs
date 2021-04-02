using UnityEngine;
using System.Collections;

[SerializeField]
public enum RingNumber
{

    twoRing,
    threeRing,
    fourRing

}

public class RingSpawner : MonoBehaviour {

    //0 is left and 1 is right
    public GameObject[] twoRings;
    public GameObject[] threeRings;
    public GameObject[] fourRings;
    public Vector3[] spawnPos;

    public RingNumber ringNumber;

    // Use this for initialization
    void Start ()
    {
        if (GameManager_HeadGames.instance.ringType == "twoRings")
        {
            ringNumber = RingNumber.twoRing;
        }
        else if (GameManager_HeadGames.instance.ringType == "threeRings")
        {
            ringNumber = RingNumber.threeRing;
        }
        else if (GameManager_HeadGames.instance.ringType == "fourRings")
        {
            ringNumber = RingNumber.fourRing;
        }

        SpawnRings();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void SpawnRings()
    {
        switch (ringNumber)
        {
            case RingNumber.twoRing:

                GameObject leftRing2 = Instantiate(twoRings[0]);
                leftRing2.transform.position = spawnPos[0];
                leftRing2.transform.rotation = Quaternion.identity;

                GameObject rightRing2 = Instantiate(twoRings[1]);
                rightRing2.transform.position = spawnPos[1];
                rightRing2.transform.rotation = Quaternion.identity;

                break;

            case RingNumber.threeRing:

                GameObject leftRing3 = Instantiate(threeRings[0]);
                leftRing3.transform.position = spawnPos[0];
                leftRing3.transform.rotation = Quaternion.identity;

                GameObject rightRing3 = Instantiate(threeRings[1]);
                rightRing3.transform.position = spawnPos[1];
                rightRing3.transform.rotation = Quaternion.identity;

                break;

            case RingNumber.fourRing:

                GameObject leftRing4 = Instantiate(fourRings[0]);
                leftRing4.transform.position = spawnPos[0];
                leftRing4.transform.rotation = Quaternion.identity;

                GameObject rightRing4 = Instantiate(fourRings[1]);
                rightRing4.transform.position = spawnPos[1];
                rightRing4.transform.rotation = Quaternion.identity;

                break;
        }
    }





}
