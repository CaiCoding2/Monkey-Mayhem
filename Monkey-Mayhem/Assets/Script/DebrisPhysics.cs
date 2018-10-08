using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPhysics : MonoBehaviour
{
    //My Code
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        print(col.gameObject.name);
        if (!col.gameObject.CompareTag("Player"))
        {
            print("You Hit debris!");
            rb2d.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            print("You DID NOT HIT DEBRIS");
        }
    }
    //My Code
}