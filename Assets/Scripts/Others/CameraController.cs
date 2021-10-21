using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _smoothness = 10f;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _player.position;
    }


    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, _offset.z + _player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, _smoothness * Time.deltaTime);
    }
}
