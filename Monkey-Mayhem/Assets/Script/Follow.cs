using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;
    // Update is called once per frame
    void LateUpdate () {//x.y.z
        if (player.transform.position.y > -.2)
        {
            transform.position = new Vector3(0f, player.transform.position.y, -10f);
        }
        if (player.transform.position.y <= -.2)
        {
            transform.position = new Vector3(0f, -0.2f , -10f);
        }
    }
}
