using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// This script is used to monitor object pooling, in it we create a specific number of object and 
/// make them active and deactive as per requirement
/// For more detail see ReadMe
/// </summary>
public class ObjectPooling_DontTouch : MonoBehaviour {

    public static ObjectPooling_DontTouch instance;

    public GameObject elephant; // ref to the game object to be pooled
    public GameObject hippo;
    public GameObject snake;
    public GameObject pig;
    public GameObject parrot;
    public GameObject panda;
    public GameObject giraffe;

    public int poolAmount;//amount of clone to create

    List<GameObject> Elephant;//get then into the list
    List<GameObject> Hippo;
    List<GameObject> Snake;
    List<GameObject> Pig;
    List<GameObject> Parrot;
    List<GameObject> Panda;
    List<GameObject> Giraffe;

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
        Elephant = new List<GameObject>();//at start we create ne list to avoid any problems
        Hippo = new List<GameObject>();
        Snake = new List<GameObject>();
        Pig = new List<GameObject>();
        Parrot = new List<GameObject>();
        Giraffe = new List<GameObject>();
        Panda = new List<GameObject>();

        //we create the clone of object as per poolAmount
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(elephant);
            obj.transform.parent = transform;
            obj.SetActive(false);//at start we make then inActive
            Elephant.Add(obj);//and add them to the list
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(hippo);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Hippo.Add(obj);
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(snake);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Snake.Add(obj);
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pig);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Pig.Add(obj);
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(parrot);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Parrot.Add(obj);
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(giraffe);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Giraffe.Add(obj);
        }

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(panda);
            obj.transform.parent = transform;
            obj.SetActive(false);
            Panda.Add(obj);
        }

        

    }

    //this is a method which will be used for calling gameobject from the list
    public GameObject GetElephant()
    {
        for (int i = 0; i < Elephant.Count; i++)
        {
            //here we chech the sate of object Active/dactive
            if (!Elephant[i].activeInHierarchy)
            {
                return Elephant[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(elephant);
        obj.transform.parent = transform;
        obj.SetActive(false);//if we get deactive obejct we use it
        Elephant.Add(obj);
        return obj;

    }

    public GameObject GetHippo()
    {
        for (int i = 0; i < Hippo.Count; i++)
        {
            if (!Hippo[i].activeInHierarchy)
            {
                return Hippo[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(hippo);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Hippo.Add(obj);
        return obj;

    }

    public GameObject GetSnake()
    {
        for (int i = 0; i < Snake.Count; i++)
        {
            if (!Snake[i].activeInHierarchy)
            {
                return Snake[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(snake);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Snake.Add(obj);
        return obj;

    }

    public GameObject GetPig()
    {
        for (int i = 0; i < Pig.Count; i++)
        {
            if (!Pig[i].activeInHierarchy)
            {
                return Pig[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pig);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Pig.Add(obj);
        return obj;

    }

    public GameObject GetParrot()
    {
        for (int i = 0; i < Parrot.Count; i++)
        {
            if (!Parrot[i].activeInHierarchy)
            {
                return Parrot[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(parrot);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Parrot.Add(obj);
        return obj;

    }

    public GameObject GetGiraffe()
    {
        for (int i = 0; i < Giraffe.Count; i++)
        {
            if (!Giraffe[i].activeInHierarchy)
            {
                return Giraffe[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(giraffe);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Giraffe.Add(obj);
        return obj;

    }

    public GameObject GetPanda()
    {
        for (int i = 0; i < Panda.Count; i++)
        {
            if (!Panda[i].activeInHierarchy)
            {
                return Panda[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(panda);
        obj.transform.parent = transform;
        obj.SetActive(false);
        Panda.Add(obj);
        return obj;

    }



}
