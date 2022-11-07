using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerParent;

    // Update is called once per frame
    void Update()
    {
        playerParent.transform.GetChild(0).position = new Vector3(playerParent.transform.GetChild(0).position.x, 0.90f, transform.position.z);
    }
}