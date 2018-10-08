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
		if (this.CompareTag("Banana")){
			if (other.CompareTag("Player"))
			{
				AudioManager.instance.PlaySound("Banana", transform.position, 1);
				Destroy(gameObject);
			}
		}
		if (this.CompareTag("Enemy")){
			if (other.CompareTag("Player"))
			{
				AudioManager.instance.PlaySound("Death", transform.position, 1);
				Destroy(gameObject);
			}
		}
		if (this.CompareTag("Lava")){
			if (other.CompareTag("Player"))
			{
				AudioManager.instance.PlaySound("Death", transform.position, 1);
				Destroy(gameObject);
			}
		}
	}
}
