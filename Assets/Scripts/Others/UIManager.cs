using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText,_highestScoreText;
    private int _coins;
    [SerializeField]
    private GameObject _panel;
    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Coins : 0";
        UpdateHighestScore(GameManager.Instance.highestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoin(int collected)
    {
        _coins += collected;
        GameManager.Instance.UpdateHighestScore(_coins);
        _coinText.text = "Coins : " + _coins;
    }

    public void UpdateHighestScore(int score)
    {
        _highestScoreText.text = "Highest Score :" + score;
    }

    public void collisionBehav()
    {
        _panel.SetActive(true);
    }
   public void RestartGame()
   {
        SceneManager.LoadScene(0);
        AudioController.Instance.PlaySound("Theme");
        Time.timeScale = 1f;
   }
}
