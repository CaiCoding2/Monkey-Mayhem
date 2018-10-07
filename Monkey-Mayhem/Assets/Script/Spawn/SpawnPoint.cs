using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public Transform[] spawnpoint;
    public float time;
    public GameObject[] obstacle;

    public List<Transform> possibleSpawn = new List<Transform>();



	// Use this for initialization
	void Start () {
        //fill the array with spawn
        for(int i = 0; i < spawnpoint.Length; i++)
        {
            possibleSpawn.Add(spawnpoint[i]);
        }

        //spawning
        InvokeRepeating("SpawnItem", time, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnItem()
    {
        int spawnIndex = Random.Range(0, possibleSpawn.Count);
        int spawnObject = Random.Range(0, obstacle.Length);

        GameObject NewObstacle = Instantiate(obstacle[spawnObject], spawnpoint[spawnIndex].position, Quaternion.identity) as GameObject;
        //NewObstacle.GetComponent<DestroyObstacle>();
    }
}
