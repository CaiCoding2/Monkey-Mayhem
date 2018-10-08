using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    float minXPosition = -7.5f;
    float maxXPosition = 7.5f;
    int direction = 1;
    Vector2 currPosition;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        currPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        switch(direction)
        {
            case -1:
                // Moving Right
                if (currPosition.x > minXPosition)
                {
                    currPosition.x -= 0.1f;
                }
                else
                {
                    // Hit left boundary, change direction
                    direction = 1;
                    spriteRenderer.flipX = false;
                }
                break;

            case 1:
                // Moving Left
                if (currPosition.x < maxXPosition)
                {
                    currPosition.x += 0.1f;
                }
                else
                {
                    // Hit right boundary, change direction
                    direction = -1;
                    spriteRenderer.flipX = true;
                }
                break;
        }
        transform.localPosition = new Vector2(currPosition.x, 0.0f);
    }
}
