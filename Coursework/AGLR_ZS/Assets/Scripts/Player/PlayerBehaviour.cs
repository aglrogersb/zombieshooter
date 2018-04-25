using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public delegate void UpdateHealth(int newHealth);

    public static event UpdateHealth OnUpdateHealth;

    public int health = 200;

    public GameObject player;

    public GameObject endScreen;

    void Start()
    {

        SendHealthData();

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        SendHealthData();

        if (health <= 0)
        {
            Die();
        }
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {

            OnUpdateHealth(health);

        }
    }

    void Die()
    {

        Destroy(player);

        endScreen.SetActive(true);

    }
}