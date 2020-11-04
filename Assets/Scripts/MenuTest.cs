using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuTest : MonoBehaviour
{
    // Start is called before the first frame update
    [MenuItem("Scripts/Set Flowers %g")]
    static void DoSomething()
    {
        UnityEngine.Debug.Log("Doing Something... : "+GameObject.FindGameObjectsWithTag("FlowerEnemy")[0].transform.position);
        //GameObject.FindGameObjectsWithTag("FlowerEnemy")[0].transform.position = new Vector3(-3.3f,3,0);
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("FlowerEnemy");
        float x = -8;
        float y = 3.5f;
        foreach (GameObject go in gos)
        {
            x+=2;
            go.transform.position = new Vector3(x, y, 0);
            if (17 < x)
            {
                go.transform.position = new Vector3(x - 24, y-6, 0);
            }
            else if (5 < x || 17 < x)
            {
                go.transform.position = new Vector3(x-12, y-3, 0);
            }
        }
    }
}
