using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    private int _coins;
    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Coins : 0"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoin(int collected)
    {
        _coins += collected;
        _coinText.text = "Coins : " + _coins;
    }
}
