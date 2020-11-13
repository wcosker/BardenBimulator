using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WaterBucket : MonoBehaviour
{
  //              UPGRADABLE SKILLS
  //***************************************************
    private float wateringTime;//BASE WATERING TIME
    private int uses;          //BASE USES
  //***************************************************
  //The upgraded values of these skills are held in GameData.cs
  // if ur reading this, ur cute :)

    private bool currWatering = false;
    private float countdown;
    private BasicFlower flower;
    private ProgressBar wateringProgressBar;


    /* *************************************************************************************************************
       * This class is for the WaterBucket Fucntionality. The triggerenter and stay see if the flower is waterable *
       * and if it is and you are already not watering the plant, you will begin watering it.                      *
       * The exit function checks for the flower being watered.                                                    *
       *                                                                                                           *
       * The update func has the countdown for the time spent watering because of timing reasons                   *
       *                                                                                                           *
       * The rest of the script has the maxUses incrementer and decrementer                                           *
       *************************************************************************************************************
     */

    void Start()
    {
        wateringProgressBar = GameObject.Find("WateringBar").GetComponent<ProgressBar>();
        wateringTime = GameControl.control.wateringTime;
        uses = GameControl.control.maxUses;
    }

    private void OnTriggerEnter2D(Collider2D col)//collision with flower object occurs
    {
        if (col.tag == "FlowerEnemy" && col.GetComponent<BasicFlower>().getCanHeal() && uses > 0)
        {
            flower = col.GetComponent<BasicFlower>();
            countdown = wateringTime;
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
            UnityEngine.Debug.Log("Begin watering... (FROM ENTER)");
        }
    }

    private void OnTriggerStay2D(Collider2D col)//player is already in object
    {
        if (!currWatering && col.tag == "FlowerEnemy" && col.GetComponent<BasicFlower>().getCanHeal() && uses > 0)
        {
            flower = col.GetComponent<BasicFlower>();
            countdown = wateringTime;
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
            UnityEngine.Debug.Log("Begin watering... (FROM STAY)");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (currWatering)//this is catching early leaving of watering
        {
            UnityEngine.Debug.Log("exited before watering completed!");
            wateringProgressBar.resetProgress();
            currWatering = false;
        }
    }

    void Update()
    {
        if (currWatering)//checks if flower is being watered
        {
            UnityEngine.Debug.Log(uses);
            countdown -= Time.deltaTime;
            wateringProgressBar.setProgress(countdown / wateringTime);
            if (countdown < 0)//END WATERING CYCLE
            {

                flower.resetTimer();
                currWatering = false;
                uses --;
                wateringProgressBar.resetProgress();
                //TODO: cancel water animation
            }
        }
    }
}
