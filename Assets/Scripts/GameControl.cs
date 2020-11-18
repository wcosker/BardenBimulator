using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;

public class GameControl : MonoBehaviour
{
  //*************************************
    public static GameControl control;//*
  //*************************************
    // ^^^^ This is the object that stores ALL of the players dynamic data
    //used for upgrades etc

    public int maxUses;//these are the saved player values
    public float moveSpeed;
    public float wateringTime;
    public AudioMixer mixer;

    void Awake()//if DDOL object already exists, destroy yourself bro :)
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()//set up music and all player prefs etc etc
    {
        mixer.SetFloat("musicVol", PlayerPrefs.GetFloat("musicVol", 0));
        mixer.SetFloat("fxVol", PlayerPrefs.GetFloat("fxVol", 0));
    }

    public void Save()//saves player data to a file (data.swag)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.swag";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData();

        data.maxUses = maxUses;
        data.moveSpeed = moveSpeed;
        data.wateringTime = wateringTime;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public void Load()//loads player data from file
    {
        string path = Application.persistentDataPath + "/data.swag";
        if (File.Exists(path))//if file is found input data into the local DDOL "control" object
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            maxUses = data.maxUses;
            moveSpeed = data.moveSpeed;
            wateringTime = data.wateringTime;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }

    public void musicVolume(float volume)
    {
        mixer.SetFloat("musicVol", volume);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    public void effectsVolume(float volume)
    {
        mixer.SetFloat("fxVol", volume);
        PlayerPrefs.SetFloat("fxVol", volume);
    }
}

[Serializable]
class GameData //THIS HOLDS RAW PLAYER DATA
{
    public float moveSpeed;
    public float wateringTime;
    public int maxUses;
}
