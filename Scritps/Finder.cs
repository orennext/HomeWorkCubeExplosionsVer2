using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3.0f;

    public List<Rigidbody> FindAffectedCubes(Vector3 position)
    {
        List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();

        Collider[] hitColliders = Physics.OverlapSphere(position, _explosionRadius);

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
}
