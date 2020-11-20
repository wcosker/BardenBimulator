using UnityEngine;
using UnityEngine.UI;

public class WaterBucket : MonoBehaviour
{
  //              UPGRADABLE SKILLS
  //***************************************************
    private float wateringTime;//BASE WATERING TIME
    private float uses;          //BASE USES
  //***************************************************
  //The upgraded values of these skills are held in GameData.cs
  // if ur reading this, ur cute :)

    private bool currWatering = false;
    private bool currFilling = false;
    private float countdown;
    private GameObject[] bucketUI;
    private BasicFlower flower;
    private ProgressBar wateringProgressBar;


    /* *************************************************************************************************************
       * This class is for the WaterBucket Fucntionality. The triggerenter and stay see if the flower is waterable *
       * and if it is and you are already not watering the plant, you will begin watering it.                      *
       * The exit function checks for the flower being watered.                                                    *
       *                                                                                                           *
       * The update func has the countdown for the time spent watering because of timing reasons                   *
       *                                                                                                           *
       * The rest of the script has the maxUses incrementer and decrementer                                        *
       *************************************************************************************************************
     */

    void Start()
    {
        bucketUI = GameObject.FindGameObjectsWithTag("BucketUI");
        wateringProgressBar = GameObject.Find("WateringBar").GetComponent<ProgressBar>();
        wateringTime = GameControl.control.wateringTime;
        uses = GameControl.control.maxUses + 0.00001f; ;
    }

    public void subtractUses()//simple code for other scripts to call
    {
        if (uses > 0)//TODO: fix this lol, right now it works fine up until the amount of uses left is less than one.
        {
            uses--;
            subtractUseUI();
        }
    }

    public void startRefill()//resets water bucket uses
    {
        currFilling = true;
    }

    private void subtractUseUI()
    {
        int i = bucketUI.Length - 1;
        bool flag = true;
        while(flag)
        {
            if (bucketUI[i].GetComponent<Image>().fillAmount > 0)
            {
                bucketUI[i].GetComponent<Image>().fillAmount--;
                flag = false;
            }
            i--;
        }
    }

    public void stopRefill()
    {
        currFilling = false;
    }

    private void OnTriggerEnter2D(Collider2D col)//collision with flower object occurs
    {
        if (col.tag == "FlowerEnemy" && col.GetComponent<BasicFlower>().getCanHeal() && uses >= 1)
        {
            flower = col.GetComponent<BasicFlower>();
            countdown = wateringTime;
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
        }
    }

    private void OnTriggerStay2D(Collider2D col)//player is already in object
    {
        if (!currWatering && col.tag == "FlowerEnemy" && col.GetComponent<BasicFlower>().getCanHeal() && uses >= 1)
        {
            flower = col.GetComponent<BasicFlower>();
            countdown = wateringTime;
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (currWatering)//this is catching early leaving of watering
        {
            wateringProgressBar.resetProgress();
            currWatering = false;
        }
    }

    void Update()
    {
        if (currWatering)//checks if flower is being watered
        {
            countdown -= Time.deltaTime;
            wateringProgressBar.setProgress(countdown / wateringTime);
            if (countdown < 0)//FLOWER IS NOW WATERED!!! HOORAY
            {
                subtractUseUI();
                flower.resetTimer();
                currWatering = false;
                uses--;
                wateringProgressBar.resetProgress();
                //TODO: cancel water animation
            }
        }

        if (currFilling && uses < GameControl.control.maxUses)
        {
            bucketUI[(int)Mathf.Ceil(uses - GameControl.control.maxUses + 3)].GetComponent<Image>().fillAmount += Time.deltaTime / 2;
            uses += Time.deltaTime/2;
        }
    }
}
