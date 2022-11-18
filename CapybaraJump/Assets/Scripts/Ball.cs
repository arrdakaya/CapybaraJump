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
  

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    
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




