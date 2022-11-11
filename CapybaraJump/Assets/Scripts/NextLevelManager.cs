using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    private int buildIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level " + buildIndex.ToString() + " Succeeded";

        
    }

    // Update is called once per frame
    public void NextLevel()
    {
       
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);

        }
        if (buildIndex == 8)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(buildIndex + 1);
        }
    }
}
