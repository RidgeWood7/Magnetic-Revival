using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MagnetParent : MonoBehaviour
{
    public UnityEvent disableSim;
    public UnityEvent afterStuck;

    [SerializeField] private float _animationWait;

    // just allows the other script to say "do this" and this will tell the coroutine to do it's thing (other scripts cannot do this) ALSO storing the default polarity
    public void Stick(Magnet.Polarity polarity)
    {
        StartCoroutine(OnStick());
    }

    IEnumerator OnStick()
    {
        disableSim.Invoke(); // this will disable the simulating for the player's rb AND play the animation for getting stuck
        yield return new WaitForSeconds(_animationWait);
        afterStuck.Invoke(); // this will resimulate the player's rb AND will play the animation for unsticking AND will make the player neutral
    }
}
