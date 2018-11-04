using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovemenr : MonoBehaviour {

	private bool dirRight = true;
	public float verticalSpeed;
	public float horizontalSpeed;
	int direction = 1;
	private float originalX;
	
	private void Start()
	{
		originalX = transform.position.x;
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

			if(transform.position.x >= originalX + .4f) {
				dirRight = false;
			}
       
			if(transform.position.x <= originalX - .4f) {
				dirRight = true;
			}
		}
	}
}
