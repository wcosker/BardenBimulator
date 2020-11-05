using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;

public class MenuTest : MonoBehaviour
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
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
            {-8,3.5f },
        };
        UnityEngine.Debug.Log(gridList[3, 1]);

        for (int k = 0; k < gridList.Length / 2; k++)
        {
            UnityEngine.Debug.Log(gridList[k, 0]);//gets all x values
            UnityEngine.Debug.Log(gridList[k, 0]);//gets all y values
        }
    }
}
