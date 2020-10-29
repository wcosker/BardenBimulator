using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Flower_Collision : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite healthySprite;
    private Basic_Flower_Death flower;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        flower = GetComponent<Basic_Flower_Death>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            flower.resetTimer();
            sr.sprite = healthySprite;
        }
    }
}
