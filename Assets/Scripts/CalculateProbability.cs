using UnityEngine;

public class CalculateProbability : MonoBehaviour
{
    [SerializeField] private CubeInitializer cube;

    private float _probabilityPercent;

    public bool Determine()
    {
        _probabilityPercent = Random.value;

        return _probabilityPercent <= cube.SplitChance;
    }
}
