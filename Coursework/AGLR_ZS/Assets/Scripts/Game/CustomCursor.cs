using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{

	public GameObject endScreen;

	void Start () 
	{
		
		Cursor.visible = false;

	}
	
	void Update () 
	{

		Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;

		transform.position = Camera.main.ScreenToWorldPoint(pos);

		if (endScreen.activeSelf) 
		{

			Cursor.visible = true;
			
		}
	}
}
