using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonClicked;

    private void Update()
    {
        int numberMouseButton = 0;

        if (Input.GetMouseButtonUp(numberMouseButton))
            MouseButtonClicked?.Invoke();
    }
}
