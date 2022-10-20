using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uimanager;


    private void Start()
    {
        CoinCalculator(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            Debug.Log("gameover");
            CoinCalculator(5);
            uimanager.FinishScreen();   
        }
        
    }
    public void CoinCalculator (int coin)
    {
        if (PlayerPrefs.HasKey("coinn"))
        {
            int oldCoin = PlayerPrefs.GetInt("coinn");
            PlayerPrefs.SetInt("coinn", oldCoin + coin);
        }
        else
        {
            PlayerPrefs.SetInt("coinn", 0);
        }
    }
    
}
