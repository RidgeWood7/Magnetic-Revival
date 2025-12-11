using UnityEngine;
using UnityEngine.Events;

public class ToolTips : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            onEnter.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            onExit.Invoke();
    }
}
