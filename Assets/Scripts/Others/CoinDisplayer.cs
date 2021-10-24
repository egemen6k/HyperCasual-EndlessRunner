using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisplayer : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _zSpeed;
    [SerializeField]
    private GameObject _player;
    private CharacterMovement _cm;

    private void Start()
    {
        _startPosition = transform.position;
        _cm = _player.GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        _zSpeed = _cm._speed;
        transform.position = new Vector3(_startPosition.x -1  , _startPosition.y , transform.position.z + (_zSpeed * Time.deltaTime));
    }
}
