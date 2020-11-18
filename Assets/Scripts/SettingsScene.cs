using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScene : MonoBehaviour
{
    //THIS CLASS IS FOR INITIALIZING ALL OF THE SETTINGS VALUES :)
    //Honestly you really don't need to touch this at all this should be fine once it's made
    //All of the actual settings DATA is held in GameControl.cs AND in PlayerPrefs


    public Slider musicSlider;
    public Slider fxSlider;

    void Start()
    {
        fxSlider.value = PlayerPrefs.GetFloat("fxVol", 0);
        musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0);
    }
}
