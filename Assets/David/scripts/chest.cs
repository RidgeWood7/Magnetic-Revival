using UnityEngine;

public class chest : MonoBehaviour, Interactable
{
    public bool isOpened {  get; private set; }
    public string Changerid { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;
    public Sprite closedSprite;

    public void Start()
    {
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }
   
    public void interact()
    { 
        if (!caninteract())
            return;
        OpenChest();
    }

    public bool caninteract()
    {
        return !isOpened;
    }

    public void OpenChest()
    {
        SetOpened(true);
        if (itemPrefab)
        {
            GameObject dropppedItem = Instantiate(itemPrefab, transform.position + Vector3.left, Quaternion.identity);
            
        }
    }

    
    public void SetOpened(bool Charged)
    {
        isOpened = Charged;

        if (isOpened) 
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }
}
