using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMonkeyMovement : MonoBehaviour {

	public float verticalSpeed;
	private float originalY;
	
	public GameObject BurnMonkey;
	//public Transform Butts;
	
	private void Start()
	{
		originalY = transform.position.y;
	}

	private void Update()
	{
		if (!GameUI.isPaused)
		{
			Instantiate(BurnMonkey, transform.position, Quaternion.identity);
			transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
		}
	}
}
