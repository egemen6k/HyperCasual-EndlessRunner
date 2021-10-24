using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisplayer : MonoBehaviour
{
    private Vector3 _startPosition;
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        _startPosition = transform.position;
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(_startPosition.x, _startPosition.y, _camera.transform.position.z + 19f);
    }
}
