using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private GameMaster _gameMaster;

    public event Action<Cube> CrossedCube;

    private void OnEnable()
    {
        _gameMaster.MouseButtonClicked += GetIntersectedCube;
    }

    private void OnDisable()
    {
        _gameMaster.MouseButtonClicked -= GetIntersectedCube;
    }

    public void GetIntersectedCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        {
            GameObject gameObject = raycastHit.transform.gameObject;
            Cube cube;
            if (gameObject.TryGetComponent(out cube))
                CrossedCube?.Invoke(cube);
        }
    }
}
