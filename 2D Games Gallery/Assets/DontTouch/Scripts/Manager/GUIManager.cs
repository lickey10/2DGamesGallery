using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
/// <summary>
/// This manages Ingame gui
/// For more detail see ReadMe
/// </summary>
public class GUIManager : MonoBehaviour {

    public Text instructionText;//this control our instruction text
    public Image colorCode;//this controls the color or instruction box

    public Text gameScore;
    public Animator gameOverAnim;//this play the game over panel animation
    public GameObject gameOverPanel;//control gameover panel
    public Text overScore;//control score on gameover panel
    public Text overHiScore;//control hiscore on gameover panel
    public Image scorePanel;//this is used so that when hi score is gain the color of score panel change
    public GameObject instructionPanel;//it show the instruction how to play game

    // Use this for initialization
    void Start ()
    {
        WhichBox();
        StartCoroutine(WaitForBoxName());
        if (GameManager_DontTouch.singleton.isGameStartedFirstTime == true)
        {
            instructionPanel.SetActive(true);
        }
        else
        {
            instructionPanel.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameOver();
        gameScore.text = "" + GameManager_DontTouch.singleton.currentScore;
        if (BoxDetector.instance.isGameOver == true || PlayerController_DontTouch.instance.gameOver == true)
        {
            overScore.text = "" + GameManager_DontTouch.singleton.currentScore;
            overHiScore.text = "" + GameManager_DontTouch.singleton.hiScore;
        }

        if (PlayerController_DontTouch.instance.changeScorePanelColor == true)
        {
            scorePanel.color = Color.red;
        }
	}

    //this method keep track of the box which is not to touch
    void WhichBox()
    {
        //this changes the instruction text and instruction box color to the currentBox collor
        if (GameManager_DontTouch.singleton.currentBox == "Elephant")
        {   //we track the box by getting its tag

            instructionText.text = "Don't touch Elephant";
            colorCode.color = new Color32(189, 195, 199, 100);
           
        }
        else if (GameManager_DontTouch.singleton.currentBox == "Hippo")
        {
            instructionText.text = "Don't touch Hippo";
            colorCode.color = new Color32(52, 152, 219, 100);


        }
        else if (GameManager_DontTouch.singleton.currentBox == "Snake")
        {
            instructionText.text = "Don't touch Snake";
            colorCode.color = new Color32(46, 204, 113, 100);

        }
        else if (GameManager_DontTouch.singleton.currentBox == "Pig")
        {
            instructionText.text = "Don't touch Pig";
            colorCode.color = new Color32(241, 169, 160, 100);


        }
        else if (GameManager_DontTouch.singleton.currentBox == "Parrot")
        {
            instructionText.text = "Don't touch Parrot";
            colorCode.color = new Color32(217, 30, 24, 100);

        }
        else if (GameManager_DontTouch.singleton.currentBox == "Panda")
        {
            instructionText.text = "Don't touch Panda";
            colorCode.color = new Color32(20, 20, 20, 100);

        }
        else if (GameManager_DontTouch.singleton.currentBox == "Giraffe")
        {
            instructionText.text = "Don't touch Giraffe";
            colorCode.color = new Color32(241, 196, 15, 100);


        }    
    }

    //it cpu comsuming to check for the box name 60 time a sec so we 
    //call this method to check 5 times per second
    IEnumerator WaitForBoxName()
    {
        yield return new WaitForSeconds(0.20f);// divide 100 by 20 or 1 by 0.2 and we get the frames
        WhichBox();
        StartCoroutine(WaitForBoxName());
    }

    //this check for game over and animate the game over panel 
    void GameOver()
    {
        
        if (BoxDetector.instance.isGameOver == true || PlayerController_DontTouch.instance.gameOver == true)
        {
            GameManager_DontTouch.singleton.isGameOver = true;

            //here we show normal ads after every game over
            //Uncomment this lines when google admob is imported............................................
            //AdsManager.instance.ShowInterstitial();

            gameOverAnim.Play("GameOverSlideIn");
        }
    }

    public void RetryBtn()
    {
        GameManager_DontTouch.singleton.isGameOver = false;

        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }


    public void CloseInstruction()
    {
        instructionPanel.SetActive(false);
    }







}
