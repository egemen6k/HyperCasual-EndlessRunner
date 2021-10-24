using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisplayer : MonoBehaviour
{
    private Vector3 _startPosition;
    [SerializeField]
    private Camera camera;

    private void Start()
    {
        _startPosition = transform.position;
        camera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(_startPosition.x, _startPosition.y, camera.transform.position.z + 19f);
    }
}
