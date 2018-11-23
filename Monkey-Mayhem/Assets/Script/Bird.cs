using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    float minXPosition = -7.5f;
    float maxXPosition = 7.5f;
    int direction = 0;
    Vector2 currPosition;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        currPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.flipX == false)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
	}
	
	// Update is called once per frame
	void Update () {

	    if (!GameUI.isPaused)
	    {
	        switch (direction)
	        {
	            case -1:
	                // Moving Right
	                if (currPosition.x > minXPosition)
	                {
	                    currPosition.x -= 0.03f;
	                }
	                else
	                {
	                    // Hit left boundary, change direction
	                    direction = 1;
                        spriteRenderer.flipX = !spriteRenderer.flipX;
	                }

	                break;

	            case 1:
	                // Moving Left
	                if (currPosition.x < maxXPosition)
	                {
	                    currPosition.x += 0.03f;
	                  
	                }
	                else
	                {
	                    // Hit right boundary, change direction
	                    direction = -1;
                        spriteRenderer.flipX = !spriteRenderer.flipX;
                    }

                    break;
	        }

	        transform.position = new Vector2(currPosition.x, currPosition.y);
	    }
	}
}
