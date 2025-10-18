using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _sizeFactor;
    [SerializeField] private float _chanceSeparation;
    [SerializeField] private float _multiplierScale = 0.5f;
    [SerializeField] private float _multiplierChance = 0.5f;

    [SerializeField] private Finder _finder;

    private const float _baseSize = 0.5f;

    public Renderer Renderer { get; private set; }
    public float ChanceSeparation => _chanceSeparation;
    public float SizeFactor => _sizeFactor;

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        _sizeFactor = CalculateSizeFactor();
    }

    private void OnDrawGizmosSelected()
    {
        float sizeFactor = CalculateSizeFactor();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _finder.CalculateActualExplosionRadius(sizeFactor));
    }

    public void Reduce()
    {
        _chanceSeparation *= _multiplierChance;
        transform.localScale = transform.localScale * _multiplierScale;
    }

    private float CalculateSizeFactor()
    {       
        float currentSize = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        return Mathf.Clamp01(_baseSize / currentSize);
    }
}