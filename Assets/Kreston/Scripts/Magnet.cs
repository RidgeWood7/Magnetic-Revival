using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public enum Polarity
    {
        Positive,
        Negative
    }

    #region Variables
    private Collider2D _col;
    [SerializeField] private Polarity _polarity; // false = negative
    [SerializeField] private string _targetTag = "magnet";
    [SerializeField] private float _searchRadius;
    [SerializeField] private float _minStrength, _maxStrength;
    [SerializeField] private LayerMask _magnetLayer;
    private List<Vector2> _closestPoints = new();
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
        RaycastHit2D[] hitColliders = new RaycastHit2D[0];
        
        if (_col is BoxCollider2D box)
        {
            hitColliders = Physics2D.BoxCastAll(transform.position, box.size * transform.localScale * _searchRadius, 0, Vector2.zero, 0, _magnetLayer);
        }
        else if (_col is CircleCollider2D circle)
        {
            hitColliders = Physics2D.CircleCastAll(transform.position, circle.radius * transform.localScale.magnitude * _searchRadius, Vector2.zero, 0, _magnetLayer);
        }

        _closestPoints.Clear();

        foreach (var hit in hitColliders)
        {
            float directionMult = 0;

            if (hit.collider.TryGetComponent(out Magnetism magnetism))
                directionMult = magnetism.objPolarity == _polarity ? 1 : -1;

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
            Gizmos.DrawWireCube(transform.position, box.size * transform.localScale * _searchRadius);
        }
        else if (_col is CircleCollider2D circle)
        {
            Gizmos.DrawWireSphere(transform.position, circle.radius * transform.localScale.magnitude * _searchRadius);
        }

        foreach (var point in _closestPoints)
        {
            Gizmos.DrawWireSphere(point, 0.5f);
        }
    }
}
