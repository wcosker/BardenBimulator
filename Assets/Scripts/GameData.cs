using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public float wateringTime;//starting watering time for every player
    public float moveSpeed;
    public int uses;

    public GameData(WaterBucket bucket, PlayerControls player)
    {
        wateringTime = bucket.wateringTime;
        uses = bucket.uses;
        moveSpeed = player.moveSpeed;
    }

}
