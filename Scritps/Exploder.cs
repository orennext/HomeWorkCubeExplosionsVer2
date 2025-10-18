using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private AnimationCurve forceFalloff = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
    [SerializeField] private float _baseExplosionForce = 10f;
    [SerializeField] private float _sizeToForceMultiplier = 3f;

    public void AddExplosionForce(List<Rigidbody> affectedRigidbodies, Vector3 explosionPosition, float sizeFactor, float explosionRadius)
    {
        foreach (Rigidbody rigidbody in affectedRigidbodies)
        {
            Vector3 direction = (rigidbody.position - explosionPosition);
            float distance = direction.magnitude;

            if (distance > 0)
            {
                direction.Normalize();

                float distanceFactor = Mathf.Clamp01(distance / explosionRadius);
                float forceMultiplier = forceFalloff.Evaluate(distanceFactor);
                float finalForce = CalculateActualExplosionForce(sizeFactor) * forceMultiplier;

                rigidbody.AddForce(direction * finalForce, ForceMode.Impulse);
            }
        }
    }

    private float CalculateActualExplosionForce(float sizeFactor)
    {
        return _baseExplosionForce * sizeFactor * _sizeToForceMultiplier;
    }
}
