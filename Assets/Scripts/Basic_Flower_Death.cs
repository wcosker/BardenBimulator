using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Flower_Death : MonoBehaviour
{

    public float timeTilDeath;
    private float originalTime;
    private SpriteRenderer sr;
    public Sprite redSprite;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeTilDeath;
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
        }
    }

    public void resetTimer()//this brings the flower back to "full hp"
    {
        timeTilDeath = originalTime;
    }
}