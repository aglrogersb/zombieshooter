using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    private int health;

    private float stamina;

    private int score;

    public GameObject healthBar;

    public GameObject staminaBar;

    public Text loadAmmo;

    public Text maxAmmo;

    void OnEnable()
    {

        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;

        PlayerController.OnUpdateStamina += HandleonUpdateStamina;

        AddScore.OnSendScore += HandleonSendScore;

        ShootBullet.OnUpdateAmmo += HandleonUpdateAmmo;

    }

    void OnDisable()
    {

        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;

        PlayerController.OnUpdateStamina -= HandleonUpdateStamina;

        AddScore.OnSendScore -= HandleonSendScore;

        ShootBullet.OnUpdateAmmo -= HandleonUpdateAmmo;

    }

    void HandleonUpdateHealth(int newHealth)
    {

        health = newHealth;

		RectTransform rt = healthBar.GetComponent(typeof(RectTransform)) as RectTransform;
		rt.sizeDelta = new Vector2(health, 20);

    }

    void HandleonUpdateStamina(float staminaValue)
    {

        stamina = staminaValue;

        RectTransform rt = staminaBar.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(stamina, 20);

    }

    void HandleonSendScore(int theScore)
    {

        score += theScore;

    }

    void HandleonUpdateAmmo(int load, int max)
    {

        loadAmmo.text = load.ToString("00");

        maxAmmo.text = max.ToString("000");

    }
}