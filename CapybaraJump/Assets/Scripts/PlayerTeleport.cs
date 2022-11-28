using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    
    private GameObject currentTeleporter;
    [SerializeField] bool isUp;
    [SerializeField] bool isDown;
    [SerializeField] bool isLeft;
    [SerializeField] bool isRight;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D col;
    public int power = 13;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        
            if (currentTeleporter != null)
            {
            transform.position = currentTeleporter.GetComponent<Teleport>().GetDestination().transform.position;
            
            if(isUp)
                rb.velocity = Vector3.up * power;
            if (isDown)
                rb.velocity = Vector3.down * power;
            if (isLeft)
                rb.velocity = Vector3.left * power;
            if (isRight)
                rb.velocity = Vector3.right * power;
        }
        
            
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
