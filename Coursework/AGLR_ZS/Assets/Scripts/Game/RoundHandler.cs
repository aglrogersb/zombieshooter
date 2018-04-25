using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandler : MonoBehaviour
{

    private int zombieCount = 0;
    private int roundCount = 0;

    private int totalReqDead = 0;
    private int deadCount = 0;

    private int roundNo = 0;

    public float spawnTime = 1.0f;

    public GameObject objectPrefab;

    public GameObject nextScreen;

    public GameObject player;

    public GameObject cursor;

    public Text roundTitle;

    void OnEnable()
    {

        ZombieBehaviour.OnUpdateDeadCount += HandleonUpdateDeadCount;

    }

    void OnDisable()
    {

        ZombieBehaviour.OnUpdateDeadCount -= HandleonUpdateDeadCount;

    }

    private void Start()
    {

        roundStart();

    }

    public void roundStart()
    {

        zombieCount += 2;

        roundCount = zombieCount;
        totalReqDead = zombieCount;

        deadCount = 0;


        Invoke("Spawn", spawnTime);

    }

    public void Spawn()
    {

        Instantiate(objectPrefab, transform.position, transform.rotation);

        roundCount -= 1;

        if (roundCount != 0)
        {

            Invoke("Spawn", spawnTime);

        }
    }

    void HandleonUpdateDeadCount(bool isDead)
    {
        if (isDead)
        {

            deadCount += 1;

            isDead = false;

        }

        if (deadCount == totalReqDead)
        {

            roundNo += 1;

            roundTitle.text = ("End of round " + roundNo.ToString("000") + "!");

            player.GetComponent<PlayerController>().enabled = !enabled;

            player.GetComponent<MouseController>().enabled = !enabled;

            player.GetComponent<ShootBullet>().enabled = !enabled;

            cursor.SetActive(false);

            nextScreen.SetActive(true);

        }
    }
}
