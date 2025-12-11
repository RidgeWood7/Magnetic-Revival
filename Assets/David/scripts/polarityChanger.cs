using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class polarityChanger : MonoBehaviour, Interactable
{
    public bool isOpened { get; private set; }
    public string Changerid { get; private set; }
    public Sprite openedSprite;
    public Sprite closedSprite;
    [SerializeField] private bool _isReusable;

    [SerializeField] private AudioClip changePolSFX;
    public Magnet magnetscript;

    [SerializeField] private Magnet.Polarity _polarity;
    public void Start()
    {
        Changerid ??= globalHelper.GenarateUniqueID(gameObject);
    }

    public void interact()
    {
        if (!caninteract() && !_isReusable)
        {
            return;
        }
        OpenChest();
    }

    public bool caninteract()
    {
        return !isOpened;
    }

    public void OpenChest()
    {
        SetOpened(true);
        if (magnetscript != null)
            magnetscript.SetPolarityEnum(_polarity);
    }


    public void SetOpened(bool Opened)
    {
        if (!_isReusable)
            isOpened = Opened;

        if (isOpened)
        {
            if (changePolSFX != null)
                AudioSource.PlayClipAtPoint(changePolSFX, transform.position, 1f);
            if (openedSprite != null)
                GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
        else
        {
            if (closedSprite != null)
                GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }
}