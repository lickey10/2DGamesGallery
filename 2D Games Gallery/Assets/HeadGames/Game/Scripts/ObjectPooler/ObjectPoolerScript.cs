using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerScript : MonoBehaviour {

    public static ObjectPoolerScript instance;

    public GameObject dotsBlue;
    public GameObject dotsGreen;
    public GameObject dotsRed;
    public GameObject dotsYellow;

    public int dotPoolAmounts;

    List<GameObject> DotsBlue;
    List<GameObject> DotsGreen;
    List<GameObject> DotsRed;
    List<GameObject> DotsYellow;

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

        DotsBlue = new List<GameObject>();
        DotsGreen = new List<GameObject>();
        DotsRed = new List<GameObject>();
        DotsYellow = new List<GameObject>();

        //blue
        for (int i = 0; i < dotPoolAmounts; i++)
        {
            
            GameObject obj = Instantiate(dotsBlue);
            obj.SetActive(false);
            DotsBlue.Add(obj);
            
        }

        //green
        for (int i = 0; i < dotPoolAmounts; i++)
        {

            GameObject obj = Instantiate(dotsGreen);
            obj.SetActive(false);
            DotsGreen.Add(obj);

        }

        //red
        for (int i = 0; i < dotPoolAmounts; i++)
        {

            GameObject obj = Instantiate(dotsRed);
            obj.SetActive(false);
            DotsRed.Add(obj);

        }

        //yellow
        for (int i = 0; i < dotPoolAmounts; i++)
        {

            GameObject obj = Instantiate(dotsYellow);
            obj.SetActive(false);
            DotsYellow.Add(obj);

        }

    }

    //blue
    public GameObject GetDotsBlue()
    {
        for (int i = 0; i < DotsBlue.Count; i++)
        {
            if (!DotsBlue[i].activeInHierarchy)
            {
                return DotsBlue[i];
            }
        }
        GameObject obj = new GameObject();

        obj = Instantiate(dotsBlue);

        obj.SetActive(false);
        DotsBlue.Add(obj);
        return obj;
    }

    //green
    public GameObject GetDotsGreen()
    {
        for (int i = 0; i < DotsGreen.Count; i++)
        {
            if (!DotsGreen[i].activeInHierarchy)
            {
                return DotsGreen[i];
            }
        }
        GameObject obj = new GameObject();

        obj = Instantiate(dotsGreen);

        obj.SetActive(false);
        DotsGreen.Add(obj);
        return obj;
    }

    public GameObject GetDotsRed()
    {
        for (int i = 0; i < DotsRed.Count; i++)
        {
            if (!DotsRed[i].activeInHierarchy)
            {
                return DotsRed[i];
            }
        }
        GameObject obj = new GameObject();

        obj = Instantiate(dotsRed);

        obj.SetActive(false);
        DotsRed.Add(obj);
        return obj;
    }

    public GameObject GetDotsYellow()
    {
        for (int i = 0; i < DotsYellow.Count; i++)
        {
            if (!DotsYellow[i].activeInHierarchy)
            {
                return DotsYellow[i];
            }
        }
        GameObject obj = new GameObject();

        obj = Instantiate(dotsYellow);

        obj.SetActive(false);
        DotsYellow.Add(obj);
        return obj;
    }



}
