using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject player;
    [SerializeField]
    private float SpawnInterval = 1f;
    float nextSpawn;

    Vector2 CamSize;

	// Use this for initialization
	void Start () {
        CamSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.aspect * Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnInterval;
            Vector2 SpawnLocation = new Vector2(Random.Range(-CamSize.x, CamSize.x), player.transform.position.y + CamSize.y);
            Instantiate(Obstacle, SpawnLocation, Quaternion.identity);
        }
    }
}
