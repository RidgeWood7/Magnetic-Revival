using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class polarityChanger : MonoBehaviour,Interactable
{
    public bool isOpened {  get; private set; }
    public string Changerid { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;
    public Sprite closedSprite;
    
    [SerializeField] private AudioClip changePolSFX;
    public Magnet magnetscript;

    [SerializeField] private Magnet.Polarity _polarity;
    public void Start()
    {
        
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }
   
    public void interact()
    { 
        
        if (!caninteract())
        {
           
            return;
           
        }
         OpenChest ();
            
       
    }

    public bool caninteract()
    {
        
        return !isOpened;
    }

    public void OpenChest()
    {
       
        SetOpened(true);
        magnetscript.SetPolarityEnum(_polarity);
    }

    
    public void SetOpened(bool Opened)
    {

        isOpened = Opened;

        if (isOpened)
        {
            AudioSource.PlayClipAtPoint(changePolSFX, transform.position, 1f);
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }

   
}