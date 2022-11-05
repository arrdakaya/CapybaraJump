using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public Ball Player;
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform idlePos;
    public GameObject deneme;


    void Start()
    {
        Player.isShoot = false;
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
      
    }

    
    void Update()
    {
        var denemepos = deneme.transform.GetChild(0).position;

        Debug.Log(Player.isShoot);
        if (!Player.isShoot)
        {
            SetStrips(denemepos);

        }
        else
        {
            ResetStrips();
        }

    }
    void ResetStrips()
    {
        SetStrips(idlePos.position);
    }
    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
    }
}
