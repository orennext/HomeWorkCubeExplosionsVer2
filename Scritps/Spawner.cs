using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private int _countMin = 2;
    [SerializeField] private int _countMax = 6;

    public List<Cube> CreateCubes(Cube cubeParent)
    {
        int count = Random.Range(_countMin, _countMax);
        List<Cube> cubes = new List<Cube>();

        if (count > 0)
        {
            cubeParent.Reduce();

            for (int i = 0; i < count; i++)
            {
                Cube newCube = Instantiate(cubeParent);
                _colorChanger.SelectRandomColor(newCube);
                cubes.Add(newCube);
            }

        }

        return cubes;
    }

    public void DestroyGameObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
