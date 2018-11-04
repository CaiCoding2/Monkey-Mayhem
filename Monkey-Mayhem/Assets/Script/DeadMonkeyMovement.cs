using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMonkeyMovement : MonoBehaviour {

	public float verticalSpeed;
	private float originalY;
	
	private void Start()
	{
		originalY = transform.position.y;
	}

	private void Update()
	{
		if (!GameUI.isPaused)
		{
			transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
		}
	}
}
