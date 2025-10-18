using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    [SerializeField] private float _baseSearchRadius = 3f;
    [SerializeField] private float _sizeToRadiusMultiplier = 1.5f;

    public List<Rigidbody> FindAffectedCubes(Vector3 position, float searchRadius)
    {
        List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
        Collider[] hitColliders = Physics.OverlapSphere(position, searchRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<Cube>() != null)
            {
                Rigidbody rigidbody = hitCollider.GetComponent<Rigidbody>();
                if (rigidbody != null && rigidbody != GetComponent<Rigidbody>())
                    affectedRigidbodies.Add(rigidbody);
            }
        }

        return affectedRigidbodies;
    }

    public float CalculateActualExplosionRadius(float sizeFactor)
    {
        return _baseSearchRadius * sizeFactor * _sizeToRadiusMultiplier;
    }
}
