using UnityEngine;
using System.Collections;

//If any problem see the ReadMe documents

public class PlayerController_DontTouch : MonoBehaviour {

    //we create instance og game object so it become easy to access variables of the script in another script
    public static PlayerController_DontTouch instance;

    private int score = 0;//set initial score
    private int hiScore = 0;
    public bool gameOver;//to check for gameOver
    //use this to activate multiTouch and deactivate it (false use mouse click and true use multitouch)
    public bool isMultiTouch = false; 
    [HideInInspector]public bool changeScorePanelColor;//this is the gui panel which indicates the color

    void Awake()
    {
        MakeInstance();
    }

    //this method make instance
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        //because of singleton we dont have to write GetComponenet<> etc , singleton and instance 
        // simplefy our work
        GameManager_DontTouch.singleton.currentScore = score;//at start we store score in our gameManager script
        hiScore = GameManager_DontTouch.singleton.hiScore;//we get out hiScore
    }

    void Update()
    {
        //new line added
        gameOver = BoxDetector.instance.isGameOver;

        if (isMultiTouch == false)
        {
            MouseClicked();
        }
        else
        {
            MultiTouch();
        }
        if (hiScore < score) // we check if our hi score is less than score
        {
            changeScorePanelColor = true;
            hiScore = score;//if true we set out hi score to score
            GameManager_DontTouch.singleton.hiScore = hiScore; // and save the hi score in gameManager
            GameManager_DontTouch.singleton.Save();//this save data to device
           
        }
        
    }

    void MouseClicked()
    {
        //we chekc if scrren is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //we create a ray from the position of  click on screen
            Ray hitRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //we then make hit variable to get the tag of the object to which it is hit
            RaycastHit2D hit = Physics2D.GetRayIntersection(hitRay, 100);

            //new line added
            if (gameOver == true)
                return;
            //new line added
            if (hit.collider == null)
                return;
            //we check if the tag is not equal to currentBox and the yellow limit line.
            //if not we increase score
            if (!(hit.collider.CompareTag(GameManager_DontTouch.singleton.currentBox)) && !(hit.collider.CompareTag("Detector")))
            {
                //increase score
                
                hit.collider.gameObject.SetActive(false);
                score++;//increase score by 1

                //we store our score in GameManager
                GameManager_DontTouch.singleton.currentScore = score;
                
            }
            //if we hit the object with tag of currentBox game is Over 
            else if (hit.collider.CompareTag(GameManager_DontTouch.singleton.currentBox))
            {
                //game over
                gameOver = true;
            }
        }
    }//MouseClicked

    //MultiTouch
    /// <summary>
    /// In it to detect whether the user has tapped on something, we first check if the touch phase is “Began.” 
    /// Then, we can cast a ray from the input position using the camera, and then check any Raycast collision 
    /// against that ray
    /// </summary>
    void MultiTouch()
    {
        int touches = Input.touchCount;

        if (touches > 0 || touches < 4)
        {
            for (int i = 0; i < touches; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    //we create a ray from the position of  click on screen
                    Ray hitRay = Camera.main.ScreenPointToRay(touch.position);

                    //we then make hit variable to get the tag of the object to which it is hit
                    RaycastHit2D hit = Physics2D.GetRayIntersection(hitRay, 100);

                    //new line added
                    if (gameOver == true)
                        return;
                    //new line added
                    if (hit.collider == null)
                        return;

                    //we check if the tag is not equal to currentBox and the yellow limit line.
                    //if not we increase score
                    if (!(hit.collider.CompareTag(GameManager_DontTouch.singleton.currentBox)) && !(hit.collider.CompareTag("Detector")))
                    {
                        //increase score

                        hit.collider.gameObject.SetActive(false);
                        score++;//increase score by 1

                        //we store our score in GameManager
                        GameManager_DontTouch.singleton.currentScore = score;

                    }
                    //if we hit the object with tag of currentBox game is Over 
                    else if (hit.collider.CompareTag(GameManager_DontTouch.singleton.currentBox))
                    {
                        //game over
                        gameOver = true;
                    }
                }

            }
        }
    }//MultiTouch

}
