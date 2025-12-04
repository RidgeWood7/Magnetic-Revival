using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

// NOTES: The Gizmos are not accurate when rotating a box

public class Magnet : MonoBehaviour
{
    #region Variables
    [SerializeField] private bool _background;
    public enum Polarity
    {
        Positive = 1,
        Neutral = 0,
        Negative = -1
    }
    private Collider2D _col;
    private Animator _anim;
    public Polarity _polarity;
    public float _searchRadius;
    [SerializeField] private float _minStrength, _maxStrength;
    [SerializeField] private LayerMask _magnetLayer;
    private List<Vector2> _closestPoints = new();
    public Vector2 _boxSize;
    [SerializeField] private Vector3 _castOffset;

    private MagnetParent _parentScript;

    [SerializeField] private Material _positiveMat;
    [SerializeField] private Material _negativeMat;
    [SerializeField] private Material _neutralMat;
    private ParticleSystemRenderer psr;
    #endregion

    void Start()
    {
        psr = GetComponent<ParticleSystemRenderer>();

        _parentScript = GetComponentInParent<MagnetParent>();
        if (_parentScript != null)
        {
            Debug.Log("Parent Script: " + _parentScript.gameObject.name);
        }
    }
    private void Awake()
    {
        _col = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        _col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        SetPlayerColor();

        RaycastHit2D[] hitColliders = new RaycastHit2D[0];

        // Sees what type of collider it is hitting [box : circle]
        if (_col is BoxCollider2D box)
        {
            hitColliders = Physics2D.BoxCastAll(transform.position + _castOffset, _boxSize * transform.localScale * _searchRadius, transform.eulerAngles.z, Vector2.zero, 0, _magnetLayer);
        }
        else if (_col is CircleCollider2D circle)
            hitColliders = Physics2D.CircleCastAll(transform.position + _castOffset, circle.radius * transform.localScale.magnitude * _searchRadius, Vector2.zero, 0, _magnetLayer);

        _closestPoints.Clear();

        foreach (var hit in hitColliders)
        {
            float directionMult = 0;

            if (hit.collider.TryGetComponent(out Magnet magnet))
                directionMult = (int)magnet._polarity * (int)_polarity;
            else
                return;

            Vector3 closestPoint = _col.ClosestPoint(hit.transform.position);
            _closestPoints.Add(closestPoint);

            _anim.SetBool("isattached", _background);

            if (!_background)
            {
                float dist = Vector2.Distance(hit.transform.position, closestPoint);
                float invDist = Mathf.Lerp(_maxStrength, _minStrength, dist / _searchRadius);
                hit.collider.attachedRigidbody.AddForce((hit.transform.position - closestPoint).normalized * invDist * directionMult);

                //RaycastHit2D[] contactedColliders = new RaycastHit2D[0];
            }
            else
            {
                {
                    float dist = Vector2.Distance(hit.transform.position, transform.position);
                    float invDist = Mathf.Lerp(_maxStrength, _minStrength, dist / _searchRadius);
                    hit.collider.attachedRigidbody.AddForce((hit.transform.position - transform.position).normalized * invDist * directionMult);
                    if (dist <= .4f && directionMult == -1)
                    {
                        _parentScript.Stick(_polarity);
                    }
                }
            }
        }
    }

    public void SetPlayerColor()
    {
        if ((int)_polarity == 1 && psr != null && _positiveMat != null && _negativeMat != null && _neutralMat != null) //positive
        {
            psr.material = _positiveMat;
        }
        else if ((int)_polarity == -1 && psr != null && _positiveMat != null && _negativeMat != null && _neutralMat != null) //negative
        {
            psr.material = _negativeMat;
        }
        else if ((int)_polarity == 0 && psr != null && _positiveMat != null && _negativeMat != null && _neutralMat != null) //neutral
        {
            psr.material = _neutralMat;
        }
    }

    private void OnDrawGizmos()
    {
        if (_col is BoxCollider2D box)
        {
            Gizmos.DrawWireCube(transform.position + _castOffset, _boxSize * transform.localScale * _searchRadius);
        }
        else if (_col is CircleCollider2D circle)
        {
            Gizmos.DrawWireSphere(transform.position + _castOffset, circle.radius * transform.localScale.magnitude * _searchRadius);
        }

        foreach (var point in _closestPoints)
        {
            Gizmos.DrawWireSphere(point, 0.5f);
        }
    }

    public void SetPolarity(string name)
    {
        if (Enum.TryParse(name, true, out Polarity polarity))
        {
            _polarity = polarity;
            _anim.SetFloat("Polarity", (float)_polarity);
        }
    }
}
