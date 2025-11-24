using System.Collections.Generic;
using UnityEngine;

// NOTES: The Gizmos are not accurate when rotating a box

public class Magnet : MonoBehaviour
{

    #region Variables
    public enum Polarity
    {
        Positive,
        Negative,
        Neutral
    }
    private Collider2D _col;
    public Polarity _polarity;
    [SerializeField] private float _searchRadius;
    [SerializeField] private float _minStrength, _maxStrength;
    [SerializeField] private LayerMask _magnetLayer;
    private List<Vector2> _closestPoints = new();
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private Vector3 _castOffset;
    #endregion

    private void Awake()
    {
        _col = GetComponent<Collider2D>();
    }

    private void OnValidate()
    {
        _col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        #region Magnetism Dampening For Jumping
        if (GetComponent<movement>())
        {
            
        }
        #endregion


        float currentRotationAngle = transform.eulerAngles.z;

        RaycastHit2D[] hitColliders = new RaycastHit2D[0];
        
        if (_col is BoxCollider2D box)
        {
            hitColliders = Physics2D.BoxCastAll(transform.position + _castOffset, _boxSize * transform.localScale * _searchRadius, currentRotationAngle, Vector2.zero, 0, _magnetLayer);
        }
        else if (_col is CircleCollider2D circle)
        {
            hitColliders = Physics2D.CircleCastAll(transform.position + _castOffset, circle.radius * transform.localScale.magnitude * _searchRadius, Vector2.zero, 0, _magnetLayer);
        }

        _closestPoints.Clear();

        foreach (var hit in hitColliders)
        {
            float directionMult = 0;

            if (hit.collider.TryGetComponent(out global::Polarity polarity))
                directionMult = polarity.objPolarity == _polarity ? 1 : -1;

            Vector3 closestPoint = _col.ClosestPoint(hit.transform.position);
            _closestPoints.Add(closestPoint);

            float dist = Vector2.Distance(hit.transform.position, closestPoint);
            float invDist = Mathf.Lerp(_maxStrength, _minStrength, dist / _searchRadius);

            hit.collider.attachedRigidbody.AddForce((hit.transform.position - closestPoint).normalized * invDist * directionMult);
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
}
