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
    public GameObject soundOn;
    public GameObject soundClose;
    public GameObject MenuScene;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public void Start()
    {
        if(PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
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
    public void PauseGame()
    {
       
        MenuScene.SetActive(true);
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(false);
            soundClose.SetActive(true);
            AudioListener.volume = 1;
        }
        else if(PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.SetActive(true);
            soundClose.SetActive(false);
            AudioListener.volume = 0;

        }
       
    }
    public void Sound_Open()
    {
        soundOn.SetActive(true);
        soundClose.SetActive(false);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_Close()
    {
        soundOn.SetActive(false);
        soundClose.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
}
