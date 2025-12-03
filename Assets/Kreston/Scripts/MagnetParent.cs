using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MagnetParent : MonoBehaviour
{
    private Magnet.Polarity _defaultPolarity;

    public UnityEvent whenStuck;
    public UnityEvent afterStuck;

    [SerializeField] private float _animationWait;
    [SerializeField] private float _coolingWait;

    // just allows the other script to say "do this" and this will tell the coroutine to do it's thing (other scripts cannot do this) ALSO storing the default polarity
    public void Stick(Magnet.Polarity polarity)
    {
        _defaultPolarity = polarity;
        StartCoroutine(OnStick());
    }

    IEnumerator OnStick()
    {
        foreach (Magnet childScript in GetComponentsInChildren<Magnet>())
        {
            if (childScript != null)
            {
                childScript.SetPolarity("Neutral");
                whenStuck.Invoke(); // this will disable the simulating for the player's rb AND play the animation for getting stuck
                yield return new WaitForSeconds(_animationWait);
                afterStuck.Invoke(); // this will resimulate the player's rb AND will play the animation for unsticking AND will make the player neutral
                yield return new WaitForSeconds(_coolingWait);
                childScript._polarity = _defaultPolarity;
            }
        }        
    }
}
