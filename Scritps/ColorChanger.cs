using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SelectRandomColor(Cube cube)
    {
        cube.Renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
