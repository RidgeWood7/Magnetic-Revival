using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particles : MonoBehaviour
{
    private ParticleSystem _particles;

    private void Update()
    {
        Magnet _script = GetComponent<Magnet>();
        Collider2D _col = GetComponent<Collider2D>();

        _particles = GetComponent<ParticleSystem>();

        ParticleSystem.MainModule size = _particles.main;
        size.startSizeXMultiplier = .12f / transform.localScale.x;
        size.startSizeYMultiplier = .12f / transform.localScale.y;
        size.startSizeZMultiplier = .12f / transform.localScale.z;

        if (_col is BoxCollider2D box)
        {
            ParticleSystem.ShapeModule shape = _particles.shape;
            shape.scale = _script._boxSize * _script._searchRadius;
        }
    }
}
