using UnityEngine;

public class BucketRefill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<WaterBucket>().startRefill();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<WaterBucket>().stopRefill();
        }
    }
}
