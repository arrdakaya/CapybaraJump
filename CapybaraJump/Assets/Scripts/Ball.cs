using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static Ball _instance;
    [SerializeField] private SkinManager skinManager;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D hook;
    private bool isDrag = false;
    public GameObject capybara;
    public Vector2 capybaraPos;
    public GameObject hookObject;
    public float hookPos;
    public bool isShoot = false ;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
    }
     void Update()
    {
            if (Input.touchCount > 0)
            {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

            Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                
                    if(hit.collider != null && hit.collider.tag == "Player")
                    {
                        isDrag = true;
                        capybara = hit.collider.gameObject;
                        capybaraPos = capybara.transform.position;
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
               
                    if (isDrag)
                {
                    rb.isKinematic = true;
                        capybaraPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    if(capybaraPos.x > hookObject.transform.position.x)
                    {
                        sprite.flipX = true;
                    }
                    else
                    {
                        sprite.flipX = false;
                    }
                        if(Vector3.Distance(capybaraPos,hook.position) > 2f)
                        {
                            rb.position = hook.position + (capybaraPos - hook.position).normalized * 2f;

                        }
                        else
                        {
                            rb.position = capybaraPos;
                        }
                    }
                }
            if(isDrag && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                StartCoroutine(SlingShot._instance.Release());
                GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().jumpSprite;
                rb.isKinematic = false;
                isDrag = false; 
                return;
                
            }

        }

    }

  
 
   
}

