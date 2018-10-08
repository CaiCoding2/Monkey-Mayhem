using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;

    public float value;
    // Update is called once per frame
    void LateUpdate () {//x.y.z
        //if (player.transform.position.y > value)
        //{
            transform.position = new Vector3(0f, player.transform.position.y+value, -10f);
        //}
        //if (player.transform.position.y <= value)
        //{
         //   transform.position = new Vector3(0f, value , -10f);
        //}
    }
}
