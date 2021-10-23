using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisplayer : MonoBehaviour
{
    private Vector3 __offset;
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        __offset = transform.position - _player.transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(-11.2f , 3.9f , _player.transform.position.z + __offset.z -0.5f);

    }
}
