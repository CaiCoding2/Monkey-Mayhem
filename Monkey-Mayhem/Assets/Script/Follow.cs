using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;
    // Update is called once per frame
    void LateUpdate () {//x.y.z
        transform.position = new Vector3(0f,player.transform.position.y, -10f);
	}
}
