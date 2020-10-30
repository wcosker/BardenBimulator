using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Basic_Flower : MonoBehaviour
{

    public float timeTilDeath;
    public Sprite redSprite;
    public Sprite healthySprite;

    private float originalTime;
    private SpriteRenderer sr;
    private bool canHeal = false;//flower can only be healed when timer is at certain point
    private bool currWatering = false;//check for watering bucket timing

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeTilDeath;//keep original time in data to process death
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTilDeath > 0)
        {
            timeTilDeath -= Time.deltaTime;//decrease plant health
        }

        checkFlowerHealth();//calls function that checks flowers time til death/health
    }
                                                                       //TODO: make this more dynamic, every flower should be able to call this method cleanly
    void checkFlowerHealth()
    {
        if (originalTime / 2 > timeTilDeath)
        {
            sr.sprite = redSprite;
            canHeal = true;
        }
    }

    public void resetTimer()//this brings the flower back to "full hp"
    {
        timeTilDeath = originalTime;
    }


    IEnumerator OnTriggerEnter2D(Collider2D col)                    //collision with player occurs
    {
        if (col.tag == "Player" && canHeal)
        {
            currWatering = true;
            //TODO: BEGIN WATERING ANIMATION HERE
            UnityEngine.Debug.Log("Waiting...");
            yield return new WaitForSeconds(2);
            UnityEngine.Debug.Log("Checking!");
            if (currWatering)
            {
                resetTimer();                                       //if the flower can be healed AND the player stood on it for a long enough time, it will be healed
                sr.sprite = healthySprite;                          //replaces the sprite and resets the can heal property
                canHeal = false;
                                                                    //TODO: take water out of watering bucket and make a sound?
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //TODO: cancel watering animation
        currWatering = false;
        UnityEngine.Debug.Log("U left");
    }
}