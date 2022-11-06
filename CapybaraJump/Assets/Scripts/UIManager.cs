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
    private bool isFinish;
    // Start is called before the first frame update

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public void FinishScreen()
    {
        finishScreen.SetActive(true);
        isFinish = true;
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
}
