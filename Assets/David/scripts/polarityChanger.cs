using UnityEngine;

public class polarityChanger : MonoBehaviour, Interactable
{
    public bool isCharged {  get; private set; }
    public string Changerid { get; private set; }
    public GameObject prefab;
    public Sprite uncharged;

    public void Start()
    {
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }
   
    public void interact()
    { 
        if (!caninteract())
            return;


    }

    public bool caninteract()
    {
        return !isCharged;
    }

    public void Chargetower()
    {
        SetCharge(true);
    }

    public void SetCharge(bool Charged)
    {
        if (isCharged == Charged) 
        {
            GetComponent<SpriteRenderer>().sprite = uncharged;
        }
    }
}
