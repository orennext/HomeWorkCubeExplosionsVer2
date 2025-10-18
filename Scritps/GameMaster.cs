using System;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Finder _finder;
    [SerializeField] private float _chanceMax = 100f;
    [SerializeField] private float _chanceMin = 0f;

    public event Action MouseButtonClicked;

    private void OnEnable()
    {
        _raycaster.CrossedCube += SplitCube;
        _inputReader.MouseButtonClicked += ClickMouseButton;
    }

    private void OnDisable()
    {
        _raycaster.CrossedCube -= SplitCube;
        _inputReader.MouseButtonClicked -= ClickMouseButton;
    }

    private void ClickMouseButton()
    {
        MouseButtonClicked?.Invoke();
    }

    private void SplitCube(Cube cubeParent)
    {
        float chanceSeparation = cubeParent.ChanceSeparation;

        if (IsWorkSplitCube(chanceSeparation) == false)
        {
            Vector3 explosionPosition = new Vector3(cubeParent.gameObject.transform.position.x, cubeParent.gameObject.transform.position.y, cubeParent.gameObject.transform.position.z);
            
            _spawner.DestroyGameObject(cubeParent);

            List<Rigidbody> rigidbodyFindCubes = _finder.FindAffectedCubes(explosionPosition);

            _exploder.AddExplosionForce(rigidbodyFindCubes, explosionPosition);

            return;
        }
        else
        {
            List<Cube> cubes = _spawner.CreateCubes(cubeParent);
            List<Rigidbody> rigidbodies = new List<Rigidbody>();
            
            foreach (var cube in cubes)
            {
                Rigidbody rigidbodyHit = cube.gameObject.GetComponent<Rigidbody>();
                if (rigidbodyHit != null)
                    rigidbodies.Add(rigidbodyHit);
            }

            _spawner.DestroyGameObject(cubeParent);
        }
    }

    private bool IsWorkSplitCube(float chanceSeparation)
    {
        return UnityEngine.Random.Range(_chanceMin, _chanceMax) < chanceSeparation;
    }
}
