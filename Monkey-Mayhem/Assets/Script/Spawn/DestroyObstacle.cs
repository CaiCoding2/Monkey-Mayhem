using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour {

    public float destroyTime = 3.0f;

    private SpawnPoint sp;
    public Transform mySpawnpPoint;
	// Use this for initialization
	void Start () {
        sp = GameObject.Find("SpawnLocation").GetComponent<SpawnPoint>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(destroyTime);
        
        for (int i = 0; i < sp.spawnpoint.Length; i++)
        {
            if(sp.spawnpoint[i] == mySpawnpPoint)
            {
                sp.possibleSpawn.Add(sp.spawnpoint[i]);
            }
        }
        Destroy(gameObject);
    }
}
