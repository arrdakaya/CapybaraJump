using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public void ContButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;

    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1;

    }
    public void ClothesSceneButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
   
}
