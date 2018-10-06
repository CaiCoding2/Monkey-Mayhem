using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
	
	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			AudioManager.instance.PlaySound("Banana", transform.position, 1);
			Destroy(gameObject);
		}
	}
}
