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

		if (transform.position.y > 20)
		{
			transform.position = new Vector3(transform.position.x, -6.91f, transform.position.z);
		}
	}
}
