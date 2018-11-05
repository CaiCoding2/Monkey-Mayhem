using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPhysics : MonoBehaviour
{
    public Animator animator;

    public float fallingSpeed = 10f;
    bool isFalling = true;
    public Rigidbody2D rb2d;

    public GameObject Dust;
    public Transform ButtomCenter;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isFalling)
        {
           
            transform.Translate(0, -fallingSpeed * Time.deltaTime, 0);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("OnCollisionEnter2D");
        //print(col.gameObject.name);
        if (!col.gameObject.CompareTag("Player"))
        {// collider other object other than player
            isFalling = false;
            transform.Translate(0, 0, 0);
            Instantiate(Dust, ButtomCenter.position, Quaternion.identity);
            //rb2d.bodyType = RigidbodyType2D.Static;
        }

    }
}