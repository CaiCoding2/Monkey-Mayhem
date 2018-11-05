using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	public float verticalSpeed;
	
	void Start ()
	{
		
	}

	private void Update()
	{	
		transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
	}
}
