using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10.0f;
    [SerializeField] private float _explosionRadius = 3.0f;
    [SerializeField] private AnimationCurve forceFalloff = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

    public void AddExplosionForce(List<Rigidbody> affectedRigidbodies, Vector3 explosionPosition)
    {
        foreach (Rigidbody rigidbody in affectedRigidbodies)
        {
            Vector3 direction = (rigidbody.position - explosionPosition);
            float distance = direction.magnitude;

            if (distance > 0)
            {
                direction.Normalize();

                float distanceFactor = Mathf.Clamp01(distance / _explosionRadius);
                float forceMultiplier = forceFalloff.Evaluate(distanceFactor);
                float finalForce = (_explosionForce * forceMultiplier);

                rigidbody.AddForce(direction * finalForce, ForceMode.Impulse);
            }
        }
    }
}
