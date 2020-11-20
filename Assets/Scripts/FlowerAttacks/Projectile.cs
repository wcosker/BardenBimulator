using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float countdown;
    public GameObject player;

    void Awake()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<Rigidbody2D>().AddForce(transform.right * 30);
        Destroy(gameObject, 10);
        countdown = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && countdown < Time.time - 4)
        {
            //TODO: ANIMATION/OTHER EFFECTS HERE
            col.GetComponent<WaterBucket>().subtractUses();
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && countdown < Time.time - 4)
        {
            //TODO: ANIMATION/OTHER EFFECTS HERE
            col.GetComponent<WaterBucket>().subtractUses();
            Destroy(gameObject);
        }
    }
}
