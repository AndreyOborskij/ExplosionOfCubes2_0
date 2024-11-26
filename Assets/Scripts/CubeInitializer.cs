using UnityEngine;

public class CubeInitializer : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _generation = 1f;

    public float SplitChance => _splitChance;
    public float Generation => _generation;

    public void Init(Color color, Vector3 size,float splitChance, float generation)
    {
        GetComponent<Renderer>().material.color = color;
        transform.localScale = size;
        _splitChance = splitChance;
        _generation = generation;
    }
}