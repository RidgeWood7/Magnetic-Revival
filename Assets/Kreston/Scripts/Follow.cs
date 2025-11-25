using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float speed = 1.0f;
    private ParticleSystem _particles;

    private void Update()
    {
        Magnet _parentScript = _target.GetComponent<Magnet>();
        Collider2D _col = _target.GetComponent<Collider2D>();
        _particles = GetComponent<ParticleSystem>();

        ParticleSystem.MainModule size = _particles.main;
        size.startSizeXMultiplier = .05f / transform.localScale.x;
        size.startSizeYMultiplier = .05f / transform.localScale.y;
        size.startSizeZMultiplier = .05f / transform.localScale.z;

        if (_col is BoxCollider2D box)
        {
            ParticleSystem.ShapeModule shape = _particles.shape;
            shape.scale = _parentScript._boxSize * _parentScript._searchRadius;
        }


        _target = GetComponentInParent<GameObject>();
        
        if (_target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, _target.transform.position, speed);
    }
}
