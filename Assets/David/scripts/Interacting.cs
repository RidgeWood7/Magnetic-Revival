using UnityEngine;
using UnityEngine.InputSystem;

public class Interacting : MonoBehaviour
{
    private Interactable InRange = null; // closest interactable
    public GameObject interactIcon;
    private void Start()
    {
       interactIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InRange?.interact();

            Debug.Log("interact pressed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Interactable interactable) && interactable.caninteract())
        {
            InRange = interactable;
            interactIcon.SetActive(true);
            Debug.Log("interactable");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable) && interactable == InRange)
        {
            InRange = null;
            interactIcon.SetActive(false);
        }
    }

}
