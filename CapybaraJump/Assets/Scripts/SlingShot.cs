using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public static SlingShot _instance;
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform idlePos;
    public GameObject capyParentPos;
    public GameObject capybara;
    private int capyNumber = 0;
    public Transform playerPos;
    GameObject capy;
    public Transform capyParent;
    private bool isShoot = false;

    [SerializeField] private SkinManager skinManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D hook;


    Camera cam;
    public Ball ball;
    [SerializeField] float pushForce = 4f;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    public Trajectory trajectory;
    public Vector2 capybaraPos;
    private bool isDrag = false;
    public float hookPos;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        
        cam = Camera.main;
        ball.DesactiveRb();
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        trajectory.Hide();

    }
    void Update()
    {
        capybara = capyParent.GetChild(0).gameObject;
        rb = capyParent.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        ball = capyParent.GetChild(0).gameObject.GetComponent<Ball>();
        var denemepos = capyParentPos.transform.GetChild(0).position;

        if (!isShoot)
        {
            SetStrips(denemepos);

        }
        else
        {
            ResetStrips();
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

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    isDrag = true;
                    trajectory.Show();
                    startPoint = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                    capybaraPos = capybara.transform.position;
                }

            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (isDrag)
                {
                    rb.isKinematic = true;
                    capybaraPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    endPoint = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                    distance = Vector2.Distance(startPoint, endPoint);
                    direction = (startPoint - endPoint).normalized;
                    force = direction * distance * pushForce;
                    trajectory.UpdateDots(ball.pos, force);

                    if (Vector3.Distance(capybaraPos, hook.position) > 2f)
                    {
                        rb.position = hook.position + (capybaraPos - hook.position).normalized * 2f;

                    }
                    else
                    {
                        rb.position = capybaraPos;
                    }
                }
 
            }
            if (isDrag && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {

                isShoot = true;
                StartCoroutine("Release");
                ResetStrips();
                ball.ActivateRb();
                ball.Push(force);
                trajectory.Hide();
                capybara.GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().jumpSprite;
                rb.isKinematic = false;
                isDrag = false;
            }

        }
    }
    public IEnumerator Release()
    {
       
        if (capyNumber <= 2)
        {
            isShoot = true;

            capybara.GetComponent<SpringJoint2D>().enabled = false;
            capybara.GetComponent<Ball>().enabled = false;
            this.GetComponent<SlingShot>().enabled = false;

            yield return new WaitForSeconds(3f);
            Destroy(capybara);
            this.GetComponent<SlingShot>().enabled = true;
            capybara.GetComponent<SpringJoint2D>().enabled = true;
            capybara.GetComponent<Ball>().enabled = true;
            capybara.GetComponent<PlayerTeleport>().enabled = true;
            capybara.GetComponent<BoxCollider2D>().enabled = true;
            if (capyNumber < 3)
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
            capyNumber = 0;
        }
    }
    void instantiateCapy()
    {
        capy = (GameObject)Instantiate(capybara, playerPos.position, Quaternion.identity, capyParent);
        isShoot = false;
    }
    
}