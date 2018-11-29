using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject player;
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

			if (GameUI.isGameOver)
			{
				verticalSpeed = 0;
			}

            Debug.Log(Mathf.Abs(player.transform.position.y) - Mathf.Abs(transform.position.y));
            float deltaPos = Mathf.Abs(player.transform.position.y) - Mathf.Abs(transform.position.y);
            if (deltaPos > 25f)
            {
                verticalSpeed = 3f;
                Debug.Log("INCREASE");
            }
            else if (deltaPos <= 25)
            {
                verticalSpeed = 0.7f;
                Debug.Log("DECREASE");
            }
        }
	}
}
