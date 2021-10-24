using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Easy()
    {
        GameManager.Instance.speedStatic = 5f;
        SceneManager.LoadScene(1);
    }

    public void Medium()
    {
        GameManager.Instance.speedStatic = 10f;
        SceneManager.LoadScene(1);
    }

    public void Hard()
    {
        GameManager.Instance.speedStatic = 15f;
        SceneManager.LoadScene(1);
    }
}
