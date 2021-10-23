using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager _ui;
    private Animator _anim;
    private GameObject coinDisplay;
    private bool _animStarted;
    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _anim = GetComponent<Animator>();
        coinDisplay = GameObject.Find("CoinDisplay");
    }

    // Update is called once per frame
    void Update()
    {
        if (_animStarted)
        {
            transform.position = Vector3.Lerp(transform.position, coinDisplay.transform.position + new Vector3(0,0,1f), 4f * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position,coinDisplay.transform.position) < 3f)
        {
            _animStarted = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.UpdateCoin(1);
        _anim.SetTrigger("collected");
        _animStarted = true;
    }
}
