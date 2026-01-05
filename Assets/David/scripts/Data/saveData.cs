using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.XR.Oculus.Input;
using Unity.Collections;
using Unity.VisualScripting;


[System.Serializable]

public class saveData
{
    public Vector2 playerPosition;
 

    public List<polaritySavedata> polaritySavedata;

    public Magnet.Polarity playerPolarity;
}

[System.Serializable]

public class polaritySavedata
{
    public string polarityId;
    public bool isUsed;
}

