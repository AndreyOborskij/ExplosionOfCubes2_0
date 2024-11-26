using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private int _clickLeftMouseButton = 0;

    public event Action<CubeInitializer> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_clickLeftMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CubeInitializer body = hit.collider.GetComponent<CubeInitializer>();

                Clicked?.Invoke(body);
            }
        }
    }
}
