using System.Collections;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MagnetParent : MonoBehaviour
{

    public static bool isattached = false;
    public UnityEvent disableSim;
    public UnityEvent afterStuck;

    [SerializeField] private float _animationWait;

    // just allows the other script to say "do this" and this will tell the coroutine to do it's thing (other scripts cannot do this) ALSO storing the default polarity
    public void Stick(Magnet.Polarity polarity)
    {
        StartCoroutine(OnStick());
    }
    public void Start()
    {
        isattached = false;
    }
    IEnumerator OnStick()
    {
        isattached = true;
        GameObject.FindWithTag("Player").GetComponentInChildren<Animator>().SetBool("isAttached", true);
        disableSim.Invoke(); // this will disable the simulating for the player's rb AND play the animation for getting stuck
        yield return new WaitForSeconds(_animationWait);
        isattached = false;
        GameObject.FindWithTag("Player").GetComponentInChildren<Animator>().SetBool("isAttached", false);
        afterStuck.Invoke(); // this will resimulate the player's rb AND will play the animation for unsticking AND will make the player neutral
    }
}
