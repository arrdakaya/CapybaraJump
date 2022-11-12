using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake _instance;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public IEnumerator CameraShakes(float duration,float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
       transform.localPosition = originalPos;
    }
    public void CameraShakesCall()
    {
        StartCoroutine(CameraShakes(0.15f,0.4f));
    }
}
