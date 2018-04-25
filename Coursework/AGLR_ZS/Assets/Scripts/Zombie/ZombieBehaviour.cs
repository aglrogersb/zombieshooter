using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{

    public int health = 10;
    public int damage = 2;

    public bool isDead = false;

    public delegate void UpdateDeadCount(bool isDead);
    public static event UpdateDeadCount OnUpdateDeadCount;

    private Transform player;

    void Start()
    {

        if (GameObject.FindWithTag("Player"))
        {

            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowardsTarget>().target = player;

            GetComponent<LookAtTarget>().target = player;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.SendMessage("TakeDamage", damage);

        }
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {

            GetComponent<AddScore>().DoSendScore();

            isDead = true;

            OnUpdateDeadCount(isDead);

            Destroy(gameObject);
            
        }
    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;

    }
}
