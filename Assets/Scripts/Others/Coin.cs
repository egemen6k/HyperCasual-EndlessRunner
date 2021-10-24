using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager _ui;
    private GameObject coinDisplay;
    private CharacterMovement _cm;
    private bool _animStarted;

    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _cm = GameObject.Find("Player").GetComponent<CharacterMovement>();
        coinDisplay = GameObject.Find("CoinDisplay");
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.UpdateCoin(1);
        _animStarted = true;
    }
}
