using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager _ui;
    private GameObject coinDisplay;
    private bool _animStarted;
    private CharacterMovement _cm;

    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        coinDisplay = GameObject.Find("CoinDisplay");
        _cm = GameObject.Find("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animStarted)
        {
            transform.position = Vector3.Lerp(transform.position, coinDisplay.transform.position + new Vector3(0, 0, 2f), _cm._speed * Time.deltaTime);
        }

        if (transform.position.y > 7f)
        {
            _animStarted = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.UpdateCoin(1);
        _animStarted = true;
    }
}
