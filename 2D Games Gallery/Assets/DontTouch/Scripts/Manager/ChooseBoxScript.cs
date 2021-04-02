using UnityEngine;
using System.Collections;
/// <summary>
/// This script is responsible to the box color which is not to touch
/// For more detail see ReadMe
/// </summary>
public class ChooseBoxScript : MonoBehaviour {

    public static ChooseBoxScript instance;

    public GameObject[] boxes;//this is to keep track how many boxes are present , you can use int variable also

    public string boxTag;//to keep track of gameObject tag

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

	void Start ()
    {
        //depending on number we choose box
        int i = Random.Range(0, boxes.Length);

        if (i == 0)
        {
            //we set the box tag
            boxTag = "Elephant";
            //we save the tag which is refered by other scripts
            GameManager_DontTouch.singleton.currentBox = boxTag;//this is used for click and detect operation
            
        }
        else if (i == 1)
        {
            boxTag = "Hippo";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 2)
        {
            boxTag = "Snake";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }
        else if (i == 3)
        {
            boxTag = "Pig";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 4)
        {
            boxTag = "Parrot";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 5)
        {
            boxTag = "Panda";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 6)
        {
            boxTag = "Giraffe";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }

        StartCoroutine(ChooseBox());
    }

    IEnumerator ChooseBox()
    {
        //we change the color after every 30 sec , we can changet he time as per requirement
        yield return new WaitForSeconds(30f);//change this

        int i = Random.Range(0, boxes.Length);

        if (i == 0)
        {
            boxTag = "Elephant";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }
        else if (i == 1)
        {
            boxTag = "Hippo";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }
        else if (i == 2)
        {
            boxTag = "Snake";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }
        else if (i == 3)
        {
            boxTag = "Pig";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }
        else if (i == 4)
        {
            boxTag = "Parrot";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 5)
        {
            boxTag = "Panda";
            GameManager_DontTouch.singleton.currentBox = boxTag;
           
        }
        else if (i == 6)
        {
            boxTag = "Giraffe";
            GameManager_DontTouch.singleton.currentBox = boxTag;
            
        }

        StartCoroutine(ChooseBox());
    }
	
}
