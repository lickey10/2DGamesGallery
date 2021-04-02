using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    public static ShopScript instance;
    public Text totalPoint;
    public GameObject shopPanel;
    public Button shopCloseBtn, animalBtn, footballBtn, pokeballBtn, poolballBtn, shopBtn;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        totalPoint.text = "Point " + GameManager_4Animals.instance.points;

        shopBtn.GetComponent<Button>().onClick.AddListener(() => { ShopBtn(); });    //shop
        shopCloseBtn.GetComponent<Button>().onClick.AddListener(() => { ShopCloseBtn(); });    //shopclose

        //shop
        animalBtn.GetComponent<Button>().onClick.AddListener(() => { Animal(); });    //shop animal btn
        footballBtn.GetComponent<Button>().onClick.AddListener(() => { Football(); });    //shop football btn
        poolballBtn.GetComponent<Button>().onClick.AddListener(() => { Poolball(); });    //shop poolball btn
        pokeballBtn.GetComponent<Button>().onClick.AddListener(() => { Pokeball(); });    //shop pokeball btn

        TextureTrack();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TextureTrack()
    {
        if (GameManager_4Animals.instance.textureUnlocked[1])
        {
            footballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
        }

        if (GameManager_4Animals.instance.textureUnlocked[2])
        {
            poolballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
        }

        if (GameManager_4Animals.instance.textureUnlocked[3])
        {
            pokeballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    void ShopBtn()
    {
        shopPanel.SetActive(true);
    }

    void ShopCloseBtn()
    {
        shopPanel.SetActive(false);
    }

    //buy buttons

    void Animal()
    {
        if (GameManager_4Animals.instance.textureStyle != 0)
        {
            GameManager_4Animals.instance.textureStyle = 0;
            GameManager_4Animals.instance.Save();
            shopPanel.SetActive(false);
        }
    }

    void Football()
    {
        if (GameManager_4Animals.instance.textureUnlocked[1] && GameManager_4Animals.instance.textureStyle != 1)
        {
            GameManager_4Animals.instance.textureStyle = 1;
            GameManager_4Animals.instance.Save();
            shopPanel.SetActive(false);
        }
        else
        {
            if (GameManager_4Animals.instance.points >= 50)
            {
                GameManager_4Animals.instance.points -= 50;
                GameManager_4Animals.instance.textureUnlocked[1] = true;
                GameManager_4Animals.instance.textureStyle = 1;
                GameManager_4Animals.instance.Save();
                footballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
                shopPanel.SetActive(false);
            }
            else
            {
                Debug.Log("No Points");
                //pop iap menu
            }
        }
    }

    void Poolball()
    {
        if (GameManager_4Animals.instance.textureUnlocked[2] && GameManager_4Animals.instance.textureStyle != 2)
        {
            GameManager_4Animals.instance.textureStyle = 2;
            GameManager_4Animals.instance.Save();
            shopPanel.SetActive(false);
        }
        else
        {
            if (GameManager_4Animals.instance.points >= 100)
            {
                GameManager_4Animals.instance.points -= 100;
                GameManager_4Animals.instance.textureUnlocked[2] = true;
                GameManager_4Animals.instance.textureStyle = 2;
                GameManager_4Animals.instance.Save();
                poolballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
                shopPanel.SetActive(false);
            }
            else
            {
                Debug.Log("No Points");
                //pop iap menu
            }
        }
    }

    void Pokeball()
    {
        if (GameManager_4Animals.instance.textureUnlocked[3] && GameManager_4Animals.instance.textureStyle != 3)
        {
            GameManager_4Animals.instance.textureStyle = 3;
            GameManager_4Animals.instance.Save();
            shopPanel.SetActive(false);
        }
        else
        {
            if (GameManager_4Animals.instance.points >= 150)
            {
                GameManager_4Animals.instance.points -= 150;
                GameManager_4Animals.instance.textureUnlocked[3] = true;
                GameManager_4Animals.instance.textureStyle = 3;
                GameManager_4Animals.instance.Save();
                pokeballBtn.transform.GetChild(1).GetComponent<Text>().text = "";
                shopPanel.SetActive(false);
            }
            else
            {
                Debug.Log("No Points");
                //pop iap menu
            }
        }
    }

}
