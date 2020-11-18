using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float countdown = 10;
    public GameObject player;

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<Rigidbody2D>().AddForce(transform.right * 30);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && countdown < 6)
        {
            //TODO: ANIMATION/OTHER EFFECTS HERE
            col.GetComponent<WaterBucket>().subtractUses();
            Destroy(gameObject);
        }
    }
}
