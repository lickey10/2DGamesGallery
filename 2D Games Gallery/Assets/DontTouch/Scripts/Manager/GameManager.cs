
/// <summary>
/// This Script is used to store data (score , music , etc) on the device
/// for more detail see ReadMe
/// </summary>
using UnityEngine;
using System.Collections;
using System;
using System.IO;//this is used to get access to read and write data on device
using System.Runtime.Serialization.Formatters.Binary;//this convert the data into binary format

public class GameManager_DontTouch : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
    private GameData_DontTouch data; // we call our saving class

    //we make our gameObject singleton so that we have only one of it in every scene
    public static GameManager_DontTouch singleton;

    public bool isGameOver = false;

    public int currentScore;//store current score which we will use in game
    public int hiScore;//for hi score
    public string currentBox; //this is to check which box should not be clicked
    public bool isMusicOn;//music state
    public bool isGameStartedFirstTime;


    void Awake()
    {
        MakeSingleton();
        InitializeVariables();
    }

    //this method is responsible to assuring that we have only 1 gameobject this script is attached in th scene
    void MakeSingleton()
    {
        //we check if object is not null we destroy it , is it implemented when we move from 1 scene to another
        // and we have same gameobject in that scene too 
        if (singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //here we initialize our variable like score , music etc
    void InitializeVariables()
    {
        Load();
        if (data != null)
        {
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();

        }
        else
        {
            isGameStartedFirstTime = true;
        }

        if (isGameStartedFirstTime)
        {
            hiScore = 0;
            isGameStartedFirstTime = false;
            isMusicOn = true;

            data = new GameData_DontTouch();

            //here we set the values of respective variables in there respective methods which we have created
            // in GameData class
            data.setIsGameStartedFirstTime(isGameStartedFirstTime);
            data.setIsMusicOn(isMusicOn);
            data.setHighScore(hiScore);

            Save();
            Load();
        }
        else
        {
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
            isMusicOn = data.getIsMusicOn();
            hiScore = data.getHighScore();
        }
    }

    public void Save()
    {
        //we check for file
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "GameData.dat");//here we create file to save
            if (data != null)
            {
                data.setIsGameStartedFirstTime(isGameStartedFirstTime);
                data.setIsMusicOn(isMusicOn);
                data.setHighScore(hiScore);
                bf.Serialize(file, data);

            }
        }
        catch (Exception e)
        { }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
        
    }

    public void Load()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "GameData.dat", FileMode.Open);//here we get saved file
            data = (GameData_DontTouch)bf.Deserialize(file);
        }
        catch (Exception e) { }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

}
/// <summary>
/// We create a class to setting and getting the required data
/// </summary>
[Serializable]
public class GameData_DontTouch
{
    public bool isGameStartedFirstTime; //this bool is used to check game started for first time or not
    private bool isMusicOn;//this store music state
    private int hiScore;//this store hi score

    //this is setter method used to set the data 
    public void setHighScore(int hiScore)
    {
        this.hiScore = hiScore;
    }
    //this is setter method used to get the data 
    public int getHighScore()
    {
        return this.hiScore;
    }

    public void setIsGameStartedFirstTime(bool isGameStartedFirstTime)
    {
        this.isGameStartedFirstTime = isGameStartedFirstTime;
    }

    public bool getIsGameStartedFirstTime()
    {
        return this.isGameStartedFirstTime;
    }

    public void setIsMusicOn(bool isMusicOn)
    {
        this.isMusicOn = isMusicOn;
    }

    public bool getIsMusicOn()
    {
        return this.isMusicOn;
    }
}