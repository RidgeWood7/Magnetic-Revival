using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Update()
    {
                   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            Debug.Log("in range");
        }

    }
} 