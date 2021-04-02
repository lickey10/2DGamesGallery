using UnityEngine;
using System.Collections;
/// <summary>
/// This script is responsible for deactivating and providing force to the box
/// For more detail see ReadMe
/// </summary>
public class BoxController : MonoBehaviour {

    public static BoxController instance;

    private Rigidbody2D myBody;//we get the rigidbody of gameobjetc to which this script is attached

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        //assign the velocity to gameobject
        //BoxSpawner.instance.forceY with this we get the forceY value and assign it here
        myBody.velocity = new Vector2(0, BoxSpawner.instance.forceY);


    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

        myBody = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {

        myBody.velocity = new Vector2(0, BoxSpawner.instance.forceY);
        
        //we check if game over is true
        //game over is possible by two ways i
        //1st if we click wrong box and 2nd we  allow wrong box to pass through yellow bar
        if (BoxDetector.instance.isGameOver == true || PlayerController_DontTouch.instance.gameOver == true)
        {
            myBody.velocity = new Vector2(0, 0);

        }

        if (GameManager_DontTouch.singleton.currentBox == this.tag)
        {
            if (transform.position.y == 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    //this make gameobject deactive
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
            this.gameObject.SetActive(false);
        }
    }


}
