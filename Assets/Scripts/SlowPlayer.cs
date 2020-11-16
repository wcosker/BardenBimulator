﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") col.GetComponent<PlayerControls>().setCharSpeed(3f);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player") col.GetComponent<PlayerControls>().setCharSpeed(GameControl.control.moveSpeed);
    }

    void Update()
    {
        gameObject.transform.localScale += new Vector3(0.001f, 0.001f, 0f);
        gameObject.GetComponent<CircleCollider2D>().radius = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2.06f;
    }
}
