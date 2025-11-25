using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PowerSensor : MonoBehaviour
{
    public UnityEvent Powering;
    #region Variables
    private bool _isActive;
    private bool _isLockedOn;
    #endregion
    #region List of Objs
    [SerializeField] private List<GameObject> _objs;
    #endregion

    // Functions
    #region OnCollision Enter/Exit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Magnet magScript = collision.gameObject.GetComponent<Magnet>();

        if (magScript != null && magScript._polarity != Magnet.Polarity.Neutral)
            _isActive = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isActive = false;
    }
    #endregion
    #region Chain Reaction (update)
    private void Update()
    {
        StartCoroutine(ChainReaction());
    }
    IEnumerator ChainReaction()
    {
        if (_isActive)
        {
            foreach (GameObject obj in _objs)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(.25f);
            }
            _isLockedOn = true;
            Powering.Invoke();
        }
        else if (!_isLockedOn)
        {
            foreach (GameObject obj in _objs)
            {
                StopAllCoroutines();
                obj.SetActive(false);
            }
        }
    }
    #endregion
}
