using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int highestScore = 0;
    private UIManager _ui;
    public float speedStatic;
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        speedStatic = 15f; // for debug purposes

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighestScore(int score)
    {
        if (score > highestScore)
        {
            highestScore = score;
            _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
            _ui.UpdateHighestScore(highestScore);
        }
    }
}
