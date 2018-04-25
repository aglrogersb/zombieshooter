using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	
	public Button restartButton;
	public Button quitButton;

	void Start()
	{

		restartButton.onClick.AddListener(delegate { restartClicked(); });

		quitButton.onClick.AddListener(delegate { quitClicked(); });

	}

	void restartClicked()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}

	void quitClicked()
	{

		Application.Quit();

	}
}
