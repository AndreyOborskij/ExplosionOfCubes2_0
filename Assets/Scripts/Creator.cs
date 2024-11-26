using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 6;
    private float _increaseGeneration = 1f;
    private int _decreaseSize = 2;
    private int _decreasePercent = 2;

    private void OnEnable()
    {
        _destroyer.Destroyed += CreateCube;
    }

    private void OnDisable()
    {
        _destroyer.Destroyed -= CreateCube;
    }

    private void CreateCube(CubeInitializer cube)
    {
        int countCubes = Random.Range(_minCountCubes, _maxCountCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            CubeInitializer copy = Instantiate(cube);

            CreateDifferences(copy);
        }
    }

    private void CreateDifferences(CubeInitializer newCube)
    {
        Color newColor = Random.ColorHSV();
        Vector3 newSize = newCube.transform.localScale / _decreaseSize;
        float splitChance = newCube.SplitChance / _decreasePercent;
        float generation = newCube.Generation + _increaseGeneration;

        newCube.Init(newColor, newSize, splitChance, generation);
    }
}
