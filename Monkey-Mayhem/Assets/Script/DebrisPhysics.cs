using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPhysics : MonoBehaviour
{
    public float fallingSpeed = 10f;
    bool isFalling = true;
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isFalling)
        {
            print("falling");
            transform.Translate(0, -fallingSpeed * Time.deltaTime, 0);
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
            //print("You Hit debris!");
            //rb2d.bodyType = RigidbodyType2D.Static;
        }

    }
}