using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject player;
    public Collider2D [] colliders;
    [SerializeField]
    private float SpawnInterval = 1f;
    float nextSpawn;


    Vector2 CamSize;

	// Use this for initialization
	void Start () {
      
        CamSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.aspect * Camera.main.orthographicSize);

    }
	

    public void spawnObstacle()
    {
        bool canSpawn = false;
        Vector2 SpawnLocation = new Vector2(0,0);

        while (!canSpawn)
        {
            SpawnLocation = new Vector2(Random.Range(-CamSize.x, CamSize.x), player.transform.position.y + CamSize.y);

            canSpawn = PreventSpawnOverlap(SpawnLocation);
            if (canSpawn)
            {
                break;
            }
        }

        GameObject newObstacle = Instantiate(Obstacle, SpawnLocation, Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnInterval;
            spawnObstacle();
        }

        
    }
    bool PreventSpawnOverlap(Vector2 spawnPos)
    {
        colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, Vector2.Angle(Vector2.zero, transform.position));

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 center = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = center.x - width;
            float rightExtent = center.x + width;
            float BottomExtent = center.y - height;
            float TopExtent = center.y + height;
            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= BottomExtent && spawnPos.y <= TopExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
