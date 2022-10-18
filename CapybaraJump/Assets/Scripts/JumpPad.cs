using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private Animator anim;
    public float jumpForce = 10f;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("active",true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine("Jumppad");
        }
        
       
    }
    IEnumerator Jumppad()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("active", false);
    }
}
