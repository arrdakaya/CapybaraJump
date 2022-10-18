using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    public static int EnemiesAlive = 0;

    private void Start()
    {
        EnemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }
    public void Die()
    {
        EnemiesAlive--;
        Destroy(gameObject);
    }
}
