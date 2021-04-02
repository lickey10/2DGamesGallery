using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager_HeadGames : MonoBehaviour {

    public static GameManager_HeadGames instance;

    private GameData_HeadGames data;

    //data which is not stored on device but refered while game is on
    public bool isGameOver;
    public int currentScore;

    //data to store on device
    public bool isGameStartedFirstTime;
    public bool isMusicOn;
    public int hiScoreSimple;
    public int hiScoreMedium;
    public int hiScoreHell;
    public string ringType;



    void Awake()
    {
        MakeInstance();
        InitializeVariables();
    }

    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //we initialize variables here
    void InitializeVariables()
    {
        //first we load any data is avialable
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
            //when game is started for 1st time on device we set the initial values
            isGameStartedFirstTime = false;
            hiScoreSimple = 0;
            hiScoreMedium = 0;
            hiScoreHell = 0;
            isMusicOn = true;

            data = new GameData_HeadGames();

            //storing data
            data.setIsGameStartedFirstTime(isGameStartedFirstTime);
            data.setIsMusicOn(isMusicOn);
            data.setHiScoreSimple(hiScoreSimple);
            data.setHiScoreMedium(hiScoreMedium);
            data.setHiScoreHell(hiScoreHell);

            Save();

            Load();

        }
        else
        {
            //getting data
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
            isMusicOn = data.getIsMusicOn();
            hiScoreSimple = data.getHiScoreSimple();
            hiScoreMedium = data.getHiScoreMedium();
            hiScoreHell = data.getHiScoreHell();
        }
    }


    //method to save data
    public void Save()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/GameData.dat");
            if (data != null)
            {
                data.setIsGameStartedFirstTime(isGameStartedFirstTime);
                data.setHiScoreSimple(hiScoreSimple);
                data.setHiScoreMedium(hiScoreMedium);
                data.setHiScoreHell(hiScoreHell);
                data.setIsMusicOn(isMusicOn);
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

    //method to load data
    public void Load()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);//here we get saved file
            data = (GameData_HeadGames)bf.Deserialize(file);
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

[Serializable]
class GameData_HeadGames
{
    private bool isGameStartedFirstTime;
    private bool isMusicOn;
    private int hiScoreSimple;
    private int hiScoreMedium;
    private int hiScoreHell;

    //is game started 1st time
    public void setIsGameStartedFirstTime(bool isGameStartedFirstTime)
    {
        this.isGameStartedFirstTime = isGameStartedFirstTime;
    }

    public bool getIsGameStartedFirstTime()
    {
        return isGameStartedFirstTime;
    }


    //music
    public void setIsMusicOn(bool isMusicOn)
    {
        this.isMusicOn = isMusicOn;
    }

    public bool getIsMusicOn()
    {
        return isMusicOn;
    }


    //hi score simple
    public void setHiScoreSimple(int hiScoreSimple)
    {
        this.hiScoreSimple = hiScoreSimple;
    }

    public int getHiScoreSimple()
    {
        return hiScoreSimple;
    }

    //hi score medium
    public void setHiScoreMedium(int hiScoreMedium)
    {
        this.hiScoreMedium = hiScoreMedium;
    }

    public int getHiScoreMedium()
    {
        return hiScoreMedium;
    }

    //hi score hell
    public void setHiScoreHell(int hiScoreHell)
    {
        this.hiScoreHell = hiScoreHell;
    }

    public int getHiScoreHell()
    {
        return hiScoreHell;
    }

}
