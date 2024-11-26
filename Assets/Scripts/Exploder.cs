using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private float _initialExplosionForce = 2000;
    private float _initialExplosionRadius = 100;
    private float _explosionForce;
    private float _explosionRadius;

    public void ApplicationExplosion (CubeInitializer cube)
    {
        Explode(cube);
        Instantiate(_effect, cube.transform.position, Quaternion.identity);
    }

    private void Explode(CubeInitializer cube)
    {
        foreach (CubeInitializer explodebleObjects in GetExplodebleObjects(cube))
        {
            SetExplosionParameters(cube, explodebleObjects);
        }
    }

    private List<CubeInitializer> GetExplodebleObjects(CubeInitializer cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _initialExplosionRadius);

        List<CubeInitializer> cubes = new List<CubeInitializer>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                CubeInitializer cubeInitializer = hit.GetComponent<CubeInitializer>();

                if (cubeInitializer != null)
                {
                    cubes.Add(cubeInitializer);
                }
            }
        }

        return cubes;
    }

    private void SetExplosionParameters(CubeInitializer cube, CubeInitializer explodebleObjects)
    {
        Rigidbody rigidbody = explodebleObjects.GetComponent<Rigidbody>();

        float distanse = Vector3.Distance(explodebleObjects.transform.position, cube.transform.position);

        if (distanse > 0)
        {
            _explosionForce = _initialExplosionForce * explodebleObjects.Generation / distanse;
        }
        else
        {
            _explosionForce = _initialExplosionForce * explodebleObjects.Generation;
        }

        _explosionRadius = _initialExplosionRadius * explodebleObjects.Generation;

        rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }    
}
