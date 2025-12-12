using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TempRemoval : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToDisable = new List<GameObject>();
    [SerializeField] private List<GameObject> objectsToEnable = new List<GameObject>();

    private void Awake()
    {
        foreach (var obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        foreach (var obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
