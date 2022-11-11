using JetBrains.Annotations;
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
    //[SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Rigidbody2D hook;
    //private bool isDrag = false;
    //public GameObject capybara;
    //public Vector2 capybaraPos;
    //public GameObject hookObject;
    //public float hookPos;
    //public bool isShoot = false ;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    sprite = GetComponent<SpriteRenderer>();
    //    GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
    //}
    // void Update()
    //{
    //        if (Input.touchCount > 0)
    //        {

    //        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

    //        Touch touch = Input.GetTouch(0);
    //            if (touch.phase == TouchPhase.Began)
    //            {

    //                if(hit.collider != null && hit.collider.tag == "Player")
    //                {
    //                    isDrag = true;
    //                    capybara = hit.collider.gameObject;
    //                    capybaraPos = capybara.transform.position;
    //                }
    //            }
    //            if (touch.phase == TouchPhase.Moved)
    //            {

    //                if (isDrag)
    //            {
    //                rb.isKinematic = true;
    //                    capybaraPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    //                if(capybaraPos.x > hookObject.transform.position.x)
    //                {
    //                    sprite.flipX = true;
    //                }
    //                else
    //                {
    //                    sprite.flipX = false;
    //                }
    //                    if(Vector3.Distance(capybaraPos,hook.position) > 2f)
    //                    {
    //                        rb.position = hook.position + (capybaraPos - hook.position).normalized * 2f;

    //                    }
    //                    else
    //                    {
    //                        rb.position = capybaraPos;
    //                    }
    //                }
    //            }
    //        if(isDrag && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
    //        {
    //            StartCoroutine(SlingShot._instance.Release());
    //            GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().jumpSprite;
    //            rb.isKinematic = false;
    //            isDrag = false; 
    //            return;

    //        }

    //    }


    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {

    //        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;

    //    }
    //}
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D col;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>(); 
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
public void DesactiveRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;

        }
    }
}




