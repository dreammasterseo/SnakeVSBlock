using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRezalution : MonoBehaviour
{
    private float _defaultWith;
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
        _defaultWith = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    {
        _camera.orthographicSize = _defaultWith / _camera.aspect; 
    }
}
