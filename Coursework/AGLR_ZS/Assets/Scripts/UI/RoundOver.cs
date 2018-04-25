using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundOver : MonoBehaviour
{

    public Button nextButton;

    public GameObject nextScreen;

    public GameObject spawner;

    public Transform player;

    public GameObject cursor;

    void Start()
    {

        nextButton.onClick.AddListener(delegate { nextClicked(); });

    }

    void nextClicked()
    {

        player.position = new Vector3(0, 0, 0);

        Invoke("nextRound", 0.5f);

    }

    void nextRound()
    {

        nextScreen.SetActive(false);

        player.GetComponent<PlayerController>().enabled = enabled;

        player.GetComponent<MouseController>().enabled = enabled;

        player.GetComponent<ShootBullet>().enabled = enabled;

        cursor.SetActive(true);

        spawner.GetComponent<RoundHandler>().roundStart();

        Cursor.visible = false;

    }

    void Update ()
    {
		
        if (nextScreen.activeSelf)
        {
            Cursor.visible = true;
        }

	}
}
