using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public GameObject finishScreen;
    public GameObject retryScreen;
    public GameObject coin;
    public GameObject giftButton;
    public GameObject retryText;
    public GameObject coin1;
    public GameObject earnedText;
    private bool isFinish;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public void FinishScreen()
    {
        
        StartCoroutine("splash");
    }
    public void RetryScreen()
    {
        
        StartCoroutine("retry");
    }
    public void MenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator retry()
    {
        yield return new WaitForSeconds(0.3f);
        if (isFinish != true)
        {
            retryScreen.SetActive(true);
            Time.timeScale = 0;


        }
    }
    IEnumerator splash()
    {
        finishScreen.SetActive(true);
        isFinish = true;
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0;
    }
    public void AfterRewardButton()
    {
        coin.SetActive(false);
        giftButton.SetActive(false);
        retryText.SetActive(false);
        coin1.SetActive(true);
        earnedText.SetActive(true);
    }
}
