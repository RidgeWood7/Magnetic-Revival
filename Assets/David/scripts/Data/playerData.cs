using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class playerData
{
    public float[] position;

    public playerData(movement player)
    {
        position = new float[2];
        position[0] = player.transform.position.x; 
        position[0] = player.transform.position.y; 
    }
}