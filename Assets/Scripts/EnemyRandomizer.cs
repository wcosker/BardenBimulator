using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;

public class EnemyRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    [MenuItem("Scripts/Set Flowers %g")]
    static void DoSomething()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("FlowerEnemy");
        //TODO: this code is so fucking ugly LMAO there's gotta be a better way to do this but idc rn
        float[,] gridList = new float[18, 2]
        {
            {-6,3.5f },
            {-4,3.5f },
            {-2,3.5f },
            {0,3.5f },
            {2,3.5f },
            {4,3.5f },
            {-6,0.5f },
            {-4,0.5f },
            {-2,0.5f },
            {0,0.5f },
            {2,0.5f },
            {4,0.5f },
            {-6,-2.5f },
            {-4,-2.5f },
            {-2,-2.5f },
            {0,-2.5f },
            {2,-2.5f },
            {4,-2.5f },
        };

        

        for (int i = 0; i < gridList.Length / 2; i++)//shuffle the array
        {
            int rnd = UnityEngine.Random.Range(0, gridList.Length / 2);

            float tempGO = gridList[rnd,0];
            float tempGO2 = gridList[rnd, 1];

            gridList[rnd, 0] = gridList[i,0];
            gridList[rnd, 1] = gridList[i, 1];

            gridList[i, 0] = tempGO;
            gridList[i, 1] = tempGO2;
        }

        for (int k = 0; k < gos.Length; k++)
        {
            gos[k].transform.position = new Vector3(gridList[k, 0], gridList[k, 1]);
            UnityEngine.Debug.Log(gridList[k, 0]);//gets all x values
            UnityEngine.Debug.Log(gridList[k, 1]);//gets all y values
        }
    }
}
