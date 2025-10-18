using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;
    [SerializeField] private float _multiplierScale = 0.5f;
    [SerializeField] private float _multiplierChance = 0.5f;

    public Renderer Renderer { get; private set; }
    public float ChanceSeparation => _chanceSeparation;

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }

    public void Reduce()
    {
        _chanceSeparation *= _multiplierChance;
        transform.localScale = transform.localScale * _multiplierScale;
    }
}