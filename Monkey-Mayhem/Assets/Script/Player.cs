using System;
using UnityEngine;
using System.Collections;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using UnityScript.Steps;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 2;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

    float camSize;
	
	public AudioClip jump;
	public AudioClip slide;

	Controller2D controller;

	public Animator animator;
	
	public event System.Action OnDeath;
	public event System.Action OnChallengeCompletion;
	

	

	
	void Start() {
        
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        camSize = Camera.main.aspect * Camera.main.orthographicSize;

		InvokeRepeating("runningSound", 0.00f, 0.3f);
		InvokeRepeating("slidingSound", 0.0f, 0.2f);
    }

    void Update() {
	    
   
        if (transform.position.x < -camSize)
        {
            // need to check if there object in new position
            transform.position = new Vector2(camSize, transform.position.y);
        }
        if (transform.position.x > camSize)
        {
            transform.position = new Vector2(-camSize, transform.position.y);
        }

	    
        Vector2 input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
	    if (Input.GetAxis("Horizontal") == 0.0f)
	    {
		    input = new Vector2(Input.GetAxis("Axis 11"), -Input.GetAxis("Axis 12"));
	    }

	    if (GameUI.isGameOver)
	    {
		    input = new Vector2(0, 0);
	    }

	    int wallDirX = (controller.collisions.left) ? -1 : 1;

       
		animator.SetBool("SpaceBar", Input.GetKeyDown (KeyCode.Space) 
		                             || Input.GetKeyDown (KeyCode.Joystick1Button0)
		                             || Input.GetKeyDown (KeyCode.Joystick1Button1));
	    //animator.SetBool("A Button", Input.GetKeyDown (KeyCode.Joystick1Button0));
		
		animator.SetFloat("Going Up", velocity.y);
		animator.SetBool("Touching Ground", controller.collisions.below);

	    if (transform.position.y + 3.72 > ScoreTextScript.score)
	    {
		    ScoreTextScript.score = transform.position.y + 3.72f;
	    }

        float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		animator.SetFloat("Speed", Mathf.Abs(targetVelocityX));
		animator.SetFloat("Going Up", velocity.y);
        bool wallSliding = false;
        animator.SetBool("Sliding", wallSliding);
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;
			animator.SetBool("Sliding", wallSliding);
			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (input.x != wallDirX && input.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				}
				else {
					timeToWallUnstick = wallStickTime;
				}
			}
			else {
				timeToWallUnstick = wallStickTime;
			}

		}

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

	    if (controller.collisions.above && controller.collisions.below)
	    {
		    AudioManager.instance.PlaySound("Squish", transform.position, 1);
		    die();
	    }

        if (ScoreTextScript.bananaAmount == 10)
	    {
		    completeChallenge();
	    }
	    else if (ScoreTextScript.countdownSeconds < 1f)
	    {
		    AudioManager.instance.PlaySound("Enemy", transform.position, 1);
		    die();
	    }
	    
	    if (Input.GetKeyDown (KeyCode.Space) 
	        || Input.GetKeyDown(KeyCode.Joystick1Button0) 
		    || Input.GetKeyDown(KeyCode.Joystick1Button1)) 
	    {
			if (wallSliding) {	
				if (wallDirX == input.x) {
					velocity.x = -wallDirX * wallJumpClimb.x * 1.5f;
					velocity.y = wallJumpClimb.y * 1.2f;
					AudioManager.instance.PlaySound("Jump", transform.position, 1);
				}
				else if (input.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
					AudioManager.instance.PlaySound("Jump", transform.position, 1);
				}
				else {
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
					AudioManager.instance.PlaySound("Jump", transform.position, 1);
				}
			}
			if (controller.collisions.below) {
				AudioManager.instance.PlaySound("Jump", transform.position, 1);
				velocity.y = jumpVelocity;
			}
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}

	void runningSound()
	{
		if ((controller.collisions.below && (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(velocity.x) > 0.4)
		                                 && GameUI.isGameOver == false))
		{
			
				AudioManager.instance.PlaySound("Footstep", transform.position, 200f);
			
		}
	}
	
	void slidingSound()
	{
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
		{
			//AudioManager.instance.PlaySound("Slide", transform.position, 6);
		}
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{	
		if (other.CompareTag("Banana"))
		{
			AudioManager.instance.PlaySound("Banana", transform.position, 1);
			ScoreTextScript.bananaAmount++;
			Destroy(other.gameObject);
			
		}

		if (other.CompareTag("Enemy"))
		{
			die();
			AudioManager.instance.PlaySound("Enemy", transform.position, 1);
		}
		if (other.CompareTag("Lava"))
		{
			AudioManager.instance.PlaySound("Lava", transform.position, 2);
			animator.SetBool("Touched Lava", true);
			die();
		}
	}

	void die()
	{
		if (OnDeath != null) {
			OnDeath();
		}
		
		//gameObject.SetActive(false);
	}
	
	void completeChallenge()
	{
		if (OnChallengeCompletion != null) {
			OnChallengeCompletion();
		}

		gameObject.SetActive(false);
	}
}

