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
        Vector3 newPosition = new Vector3(transform.position.x , transform.position.y , _player.transform.position.z + __offset.z -0.5f);
        transform.position = newPosition;
        //transform.position = new Vector3(__offset.x - 2 , __offset.y  , (_player.transform.position.z + 10));
    }
}
