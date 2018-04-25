using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private float returnSpeed;
	private float regenSpeed = 0.5f;

    private float staminaValue = 200;

	private bool outOfStamina = false;
	private bool isRunning = false;

    public float speed;
    public float runSpeed;

    public GameObject staminaBar;

    public delegate void UpdateStamina(float staminaValue);

    public static event UpdateStamina OnUpdateStamina;

    Rigidbody2D rb2d = new Rigidbody2D();

    void Start ()
	{

        rb2d = GetComponent<Rigidbody2D>();

        returnSpeed = speed;

	}

	void FixedUpdate ()
	{

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		rb2d.velocity = new Vector2(x, y) * speed;
		rb2d.angularVelocity = 0.0f;

		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player1Walk1"))
		{

			GetComponent<Animator>().SetInteger("invertFooting", 2);

		}
		else if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player1Walk2"))
		{

			GetComponent<Animator>().SetInteger("invertFooting", 1);

		}

		if ((Input.GetKey(KeyCode.W)) ||
			(Input.GetKey(KeyCode.A)) ||
			(Input.GetKey(KeyCode.S)) ||
			(Input.GetKey(KeyCode.D)))
		{

			GetComponent<Animator>().SetBool("isWalking", true);

		}
		else
		{

			GetComponent<Animator>().SetBool("isWalking", false);

		}

		if (!outOfStamina)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{

				staminaValue -= 1;
				regenSpeed = 0.5f;
                
                SendStaminaData();

                GetComponent<Animator>().speed = 2.0f;

				speed = Mathf.Lerp (speed, runSpeed, Time.deltaTime *2.0f);

				isRunning = true;

				if (staminaValue < 0.25)
				{
					outOfStamina = true;
					isRunning = false;
					staminaBar.GetComponent<Image>().color = new Color(0, 255, 0, 0.2f);
				}
			}
			else
			{
				isRunning = false;
			}
		}

		if ((staminaValue != 200) && (isRunning == false))
		{

			staminaValue += regenSpeed;

            SendStaminaData();

            GetComponent<Animator>().speed = 1.0f;

			speed = Mathf.Lerp (speed, returnSpeed, Time.deltaTime * 2.0f);

		}

		if ((staminaValue) == 100 && (outOfStamina))
		{

			regenSpeed = 2.0f;

			outOfStamina = false;

			staminaBar.GetComponent<Image>().color = new Color(0, 225, 0, 1);

		}
	}

    void SendStaminaData()
    {
        if (OnUpdateStamina != null)
        {

            OnUpdateStamina(staminaValue);

        }
    }
}
