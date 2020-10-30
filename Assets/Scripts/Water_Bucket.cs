using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Water_Bucket : MonoBehaviour
{
    private bool currWatering = false;
    private float wateringTime = 2f;//this can be an upragadable skill?
    private float countdown;
    private int uses = 4;//get this value from other script upgrade?????
    private Basic_Flower flower;


    /* *************************************************************************************************************
       * This class is for the WaterBucket Fucntionality. The triggerenter and stay see if the flower is waterable *
       * and if it is and you are already not watering the plant, you will begin watering it.                      *
       * The exit function checks for the flower being watered.                                                    *
       *                                                                                                           *
       * The update func has the countdown for the time spent watering because of timing reasons                   *
       *                                                                                                           *
       * The rest of the script has the uses incrementer and decrementer                                           *
       *************************************************************************************************************
     */
    private void OnTriggerEnter2D(Collider2D col)//collision with flower object occurs
    {
        if (col.tag == "FlowerEnemy" && col.GetComponent<Basic_Flower>().getCanHeal() && uses > 0)
        {
            flower = col.GetComponent<Basic_Flower>();
            countdown = wateringTime;
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
            UnityEngine.Debug.Log("Begin watering... (FROM ENTER)");
        }
    }

    private void OnTriggerStay2D(Collider2D col)//player is already in object
    {
        if (!currWatering && col.tag == "FlowerEnemy" && col.GetComponent<Basic_Flower>().getCanHeal() && uses > 0)
        {
            flower = col.GetComponent<Basic_Flower>();
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
            currWatering = false;
        }
    }

    void Update()
    {
        if (currWatering)//checks if flower is being watered
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)//END WATERING CYCLE
            {
                //UnityEngine.Debug.Log("Flower has been healed!");
                flower.resetTimer();
                currWatering = false;
                uses--;
                //TODO: cancel water animation
            }
        }
    }
}
