using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject retryScreen;
    private bool isFinish;
    // Start is called before the first frame update
   public void FinishScreen()
    {
        finishScreen.SetActive(true);
        isFinish = true;
    }
    public void RetryScreen()
    {
        StartCoroutine("retry");
    }
    IEnumerator retry()
    {
        yield return new WaitForSeconds(0.8f);
        if (isFinish != true)
        {
            retryScreen.SetActive(true);

        }
    }
}
