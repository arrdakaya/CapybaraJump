using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public static SlingShot _instance;
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform idlePos;
    public GameObject deneme;
    private float releaseTime = 0.1f;
    public GameObject capybara;
    private int capyNumber = 0;
    public Transform playerPos;
    GameObject capy;
    public Transform capyParent;
    private bool isShoot = false;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
      
    }

    
    void Update()
    {
       
        var denemepos = deneme.transform.GetChild(0).position;

        
        if (!isShoot)
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
    public IEnumerator Release()
    {
        
        capybara = capyParent.GetChild(0).gameObject;
        if ( capyNumber <= 2)
        {
            isShoot = true;

            yield return new WaitForSeconds(releaseTime);
            capybara.GetComponent<SpringJoint2D>().enabled = false;
            capybara.GetComponent<Ball>().enabled = false;
            yield return new WaitForSeconds(2f);
            Destroy(capybara);
           
            capybara.GetComponent<SpringJoint2D>().enabled = true;
            capybara.GetComponent<Ball>().enabled = true;
            capybara.GetComponent<BoxCollider2D>().enabled = true;
            if(capyNumber < 3)
            {
                instantiateCapy();

            }
            
        }
        
        capyNumber++;
        Debug.Log(capyNumber);
        if (capyNumber == 3)
        {
            Enemy.EnemiesAlive = 0;
            UIManager._instance.RetryScreen();

        }
    }
    void instantiateCapy()
    {
        capy = (GameObject)Instantiate(capybara, playerPos.position, Quaternion.identity, capyParent);
        isShoot = false;
    }
}
