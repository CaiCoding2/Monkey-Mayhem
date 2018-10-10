using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

	private bool dirRight = true;
	public float verticalSpeed;
	public float horizontalSpeed;
	int direction = 1;
	
	void Start () {
	}

	private void Update()
	{
		if (!GameUI.isPaused)
		{

			if (dirRight)
			{
				transform.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);
				transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
			}
			else
			{
				transform.Translate(-Vector2.right * horizontalSpeed * Time.deltaTime);
				transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
			}

			if(transform.position.x >= 1.4f) {
				dirRight = false;
			}
       
			if(transform.position.x <= -1.4f) {
				dirRight = true;
			}
		}
	}
}
