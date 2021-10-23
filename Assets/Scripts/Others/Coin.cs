using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager _ui;
    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.UpdateCoin(1);
        Destroy(this.gameObject);
    }
}
