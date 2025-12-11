using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;


[System.Serializable]

public class saveData
{
    public Vector2 playerPosition;

    public List<polaritySavedata> polaritySavedata;
}

[System.Serializable]

public class polaritySavedata
{
    public string polarityId;
    public bool isUsed;
}