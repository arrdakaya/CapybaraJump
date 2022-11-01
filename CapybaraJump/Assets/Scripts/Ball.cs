using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D hook;
    private float releaseTime = 0.1f;
    [SerializeField] private GameObject nextCapybara;
    private bool isDrag = false;
    public GameObject capybara;
    public Vector2 capybaraPos;
    public GameObject hookObject;
    public float hookPos;
   

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
                StartCoroutine("Release");
                //anim.SetTrigger("jump");
                GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().jumpSprite;

                rb.isKinematic = false;

                isDrag = false; 
                return;
            }
           
            

        }
   
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if(nextCapybara != null)
        {
            nextCapybara.SetActive(true);
          
        }
        else
        {
            Enemy.EnemiesAlive = 0;
            
            
        }
    }
}

