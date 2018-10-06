using UnityEngine;
using System.Collections;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

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

	
	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        camSize = Camera.main.aspect * Camera.main.orthographicSize;

		InvokeRepeating("runningSound", 0.00f, 0.3f);
		InvokeRepeating("slidingSound", 0.0f, 1f);
    }

    void Update() {
        //player 
	    
	    
	    
        if (transform.position.x < -camSize)
        {
            // need to check if there object in new position
            transform.position = new Vector2(camSize, transform.position.y);
        }
        if (transform.position.x > camSize)
        {
            transform.position = new Vector2(-camSize, transform.position.y);
        }

        Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        int wallDirX = (controller.collisions.left) ? -1 : 1;

        
		animator.SetBool("SpaceBar", Input.GetKeyDown (KeyCode.Space));
		
		animator.SetFloat("Going Up", velocity.y);
		animator.SetBool("Touching Ground", controller.collisions.below);

        

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

	    if (Input.GetKeyDown (KeyCode.Space)) {
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
		if (controller.collisions.below && (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(velocity.x) > 0.4))
		{
			AudioManager.instance.PlaySound("Footstep", transform.position, 200f);
		}
	}
	
	void slidingSound()
	{
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
		{
			AudioManager.instance.PlaySound("Slide", transform.position, 6);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Banana"))
		{
			ScoreTextScript.bananaAmount++;
		}
	}
}

