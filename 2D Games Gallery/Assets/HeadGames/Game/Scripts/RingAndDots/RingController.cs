using UnityEngine;
using System.Collections;


[SerializeField]
public enum WhichRing
{
    left,
    right
}

[SerializeField]
public enum NumberOfColors
{
    two,
    three,
    four
}

public class RingController : MonoBehaviour {


    public static RingController instance;

    public WhichRing whichRing;
    public NumberOfColors numOfColors;

    public float speed;

    private AudioSource audioSource;

    private Vector3 rotate;

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
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();

            switch (numOfColors)
            {
                case NumberOfColors.two:

                    TwoColor();

                    break;
                case NumberOfColors.three:

                    ThreeColor();

                    break;
                case NumberOfColors.four:

                    FourColor();

                    break;

            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotate.z));

        }

    }

    void TwoColor()
    {
        Vector2 pos = Input.mousePosition;

        switch (whichRing)
        {
           
            case WhichRing.left:

                if (pos.x > 0 && pos.x < Screen.width / 2)
                {
                    rotate.z += -180;
                }

                break;

            case WhichRing.right:

                if (pos.x > Screen.width / 2 && pos.x < Screen.width)
                {
                    rotate.z += -180;
                }

                break;
        }


    }

    void ThreeColor()
    {
        Vector2 pos = Input.mousePosition;

        switch (whichRing)
        {

            case WhichRing.left:

                if (pos.x > 0 && pos.x < Screen.width / 2)
                {
                    rotate.z += -120;
                }

                break;

            case WhichRing.right:

                if (pos.x > Screen.width / 2 && pos.x < Screen.width)
                {
                    rotate.z += -120;
                }

                break;
        }


    }

    void FourColor()
    {
        Vector2 pos = Input.mousePosition;

        switch (whichRing)
        {

            case WhichRing.left:

                if (pos.x > 0 && pos.x < Screen.width / 2)
                {
                    rotate.z += -90;
                }

                break;

            case WhichRing.right:

                if (pos.x > Screen.width / 2 && pos.x < Screen.width)
                {
                    rotate.z += -90;
                }

                break;

        }
    }


}
