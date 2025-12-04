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
    [SerializeField] private AudioClip changePol;

    public void Start()
    {
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }
   
    public void interact()
    { 
        
        if (!caninteract())
        {
            SFXManager.Instance.PlaySoundFXClip(changePol, transform, 1f);
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
       
        SetOpened(true);
        //if (itemPrefab)
        //{
        //    GameObject dropppedItem = Instantiate(itemPrefab, transform.position + Vector3.left, Quaternion.identity);

        //}
    }

    
    public void SetOpened(bool Opened)
    {

        isOpened = Opened;

        if (isOpened)
        {

            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }

    public void positiveCharge()
    {
        throw new System.NotImplementedException();
    }
}