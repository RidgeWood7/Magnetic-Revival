using UnityEngine;
using UnityEngine.Events;

public class chest : MonoBehaviour, Interactable
{
    public bool isOpened {  get; private set; }
    public string Changerid { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;
    public Sprite closedSprite;
    public UnityEvent Interact;

    public void Start()
    {
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }
   
    public void interact()
    { 
        if (!caninteract())
        {
            Interact.Invoke();
            return;
        }
        //OpenChest ();
            
       
    }

    public bool caninteract()
    {
        return !isOpened;
    }

    public void OpenChest()
    {
        throw new System.NotImplementedException();
        //SetOpened(true);
        //if (itemPrefab)
        //{
        //    GameObject dropppedItem = Instantiate(itemPrefab, transform.position + Vector3.left, Quaternion.identity);

        //}
    }

    
    public void SetOpened(bool Opened)
    {
        throw new System.NotImplementedException();
        //isOpened = Opened;

        //if (isOpened) 
        //{
        //    GetComponent<SpriteRenderer>().sprite = openedSprite;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().sprite = closedSprite;
        //}
    }

    public void positiveCharge()
    {
        throw new System.NotImplementedException();
    }
}
