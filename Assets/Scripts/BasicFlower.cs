using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BasicFlower : MonoBehaviour
{

    public float timeTilDeath;
    public Sprite redSprite;
    public Sprite healthySprite;

    private float originalTime;
    private SpriteRenderer sr;
    private bool canHeal = false;//flower can only be healed when timer is at certain point

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
                                                                       
    void checkFlowerHealth()//TODO: make this more dynamic, every flower should be able to call this method cleanly
    {
        if (originalTime / 2 > timeTilDeath)
        {
            sr.sprite = redSprite;
            canHeal = true;
        }
    }

    public void resetTimer()//this brings the flower back to "full hp" changes sprite and sets the flower back to not healable
    {
        timeTilDeath = originalTime;
        sr.sprite = healthySprite;
        canHeal = false;
    }

    public bool getCanHeal()//allows other scripts to access flowers healing status
    {
        return canHeal;
    }
}