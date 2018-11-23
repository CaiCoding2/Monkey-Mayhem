using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysic : RaycastController{

    public Animator animator;
    public Vector3 falling;
    public LayerMask PlayerMask;
    //public Rigidbody2D rb2d;

    public GameObject Dust;
    public Transform ButtomCenter;

    public override void Start()
    {
        base.Start();
    }
    public void Awake()
    {
       // rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateRaycastOrigins();

        Vector3 velocity = falling * Time.deltaTime;

        FallingObstacle(velocity);
        transform.Translate(velocity);
    }

    void FallingObstacle(Vector3 velocity)
    {
        HashSet<Transform> movePlayer = new HashSet<Transform>();

        float directionX = Mathf.Sign(velocity.x);
        float directionY = Mathf.Sign(velocity.y);

        //Vertical moving 
        if(velocity.y != 0)
        {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;

            for(int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down * directionY, rayLength, collisionMask);
                Debug.DrawRay(rayOrigin, Vector2.down * directionY * rayLength, Color.green);

                if (hit)
                {
                    if (!movePlayer.Contains(hit.transform))
                    {
                        movePlayer.Add(hit.transform);
                        float pushX = (directionY == 1) ? velocity.x : 0;
                        float pushY = velocity.y - (hit.distance - skinWidth) * directionY;

                        hit.transform.Translate(new Vector3(pushX, pushY));

                    }
                    
                }
            }
        }
        if(directionY == -1 || velocity.y == 0 && velocity.x != 0)
        {
            float rayLength = skinWidth * 2;

            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, PlayerMask);
                Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

                if (hit)
                {
                    if (!movePlayer.Contains(hit.transform)) {
                        movePlayer.Add(hit.transform);
                        float pushX = velocity.x;
                        float pushY = velocity.y;

                        hit.transform.Translate(new Vector3(pushX, pushY));
                    }
                }

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {// collider other object other than player

            falling.y = 0;
            Instantiate(Dust, ButtomCenter.position, Quaternion.identity);
            animator.SetBool("IsFalling", false);
            //Instantiate(Dust, ButtomCenter.position, Quaternion.identity);
            //rb2d.bodyType = RigidbodyType2D.Static;
        }
    }
}
