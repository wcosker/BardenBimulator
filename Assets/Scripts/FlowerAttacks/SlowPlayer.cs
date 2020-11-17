using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    private float sinSize = 3;
    private float origSizeRadii;
    private BasicFlower flowerObj;
    private WaterBucket waterBucket;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") col.GetComponent<PlayerControls>().setCharSpeed(3f);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player") col.GetComponent<PlayerControls>().setCharSpeed(GameControl.control.moveSpeed);
    }

    void Start()
    {
        origSizeRadii = sinSize;
        flowerObj = gameObject.GetComponentInParent<BasicFlower>();
    }

    void Update()
    {
        if (flowerObj.getCanHeal() && sinSize < 5)
        {
            growRadii();
        }
        else if (!flowerObj.getCanHeal() && sinSize > origSizeRadii)
        {
            shrinkRadii();
        }
        gameObject.transform.localScale = new Vector3(Mathf.Sin(Time.time / 1.2f) / 8 + sinSize, Mathf.Sin(Time.time / 1.2f) / 8 + sinSize, 0f);
        gameObject.GetComponent<CircleCollider2D>().radius = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2.06f;
    }

    private void growRadii()
    {
        sinSize += Time.deltaTime/12;
    }

    private void shrinkRadii()
    {
        sinSize -= Time.deltaTime / 2;
    }

    public void setCircleSize(float newSize)
    {
        sinSize = newSize;
    }
}
