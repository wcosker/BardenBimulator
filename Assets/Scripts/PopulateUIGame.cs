using UnityEngine;
using UnityEngine.UI;

public class PopulateUIGame : MonoBehaviour
{
    public GameObject UIBucket;
    private int bucketUses;
    private GameObject canvas;
    private RectTransform size;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        bucketUses = GameControl.control.maxUses;
        size = canvas.GetComponent<RectTransform>();
        for (int i = 0; i < bucketUses; i++)
        {
            //gameObject.anchorPosition = new Vector3(...)
            GameObject temp = Instantiate(UIBucket) as GameObject;
            temp.transform.SetParent(canvas.transform);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(i*110 - (size.anchoredPosition.x - 60), size.anchoredPosition.y - 60, 0);
        }
    }
}
