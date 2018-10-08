using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject player;
    GameObject SpawnObstacle;
    public Collider2D[] colliders;
    public float size;

    Vector2 spawnLocation;
    [SerializeField]
    private float SpawnInterval = 1f;
    float nextSpawn;

    Vector2 CamSize;

	// Use this for initialization
	void Awake () {
        //get camera size
        CamSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.aspect * Camera.main.orthographicSize);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnInterval;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            spawnLocation = new Vector2(Random.Range(-CamSize.x + 2f, CamSize.x - 2f), player.transform.position.y+CamSize.y + 2* CamSize.y);
            GameObject spawnObstacle = Instantiate(Obstacle, spawnLocation, Quaternion.identity) as GameObject;

            //change scale 
            //spawnObstacle.transform.localScale = spawnObstacle.transform.localScale * Random.Range(0.4f,0.6f);
=======
            spawnLocation = new Vector2(Random.Range(-CamSize.x + 0.2f, CamSize.x - 0.2f), player.transform.position.y+CamSize.y + 5f);
            GameObject spawnObstacle = Instantiate(Obstacle, spawnLocation, Quaternion.identity) as GameObject;

            //change scale 
            spawnObstacle.transform.localScale = spawnObstacle.transform.localScale * Random.Range(0.7f,1.5f);
>>>>>>> parent of c91bd13... Merge branch 'master' of https://github.com/CaiCoding2/Monkey-Mayhem
=======
            spawnLocation = new Vector2(Random.Range(-CamSize.x + 0.2f, CamSize.x - 0.2f), player.transform.position.y+CamSize.y + 5f);
            GameObject spawnObstacle = Instantiate(Obstacle, spawnLocation, Quaternion.identity) as GameObject;

            //change scale 
            spawnObstacle.transform.localScale = spawnObstacle.transform.localScale * Random.Range(0.7f,1.5f);
>>>>>>> parent of c91bd13... Merge branch 'master' of https://github.com/CaiCoding2/Monkey-Mayhem
=======
            spawnLocation = new Vector2(Random.Range(-CamSize.x + 0.2f, CamSize.x - 0.2f), player.transform.position.y+CamSize.y + 5f);
            GameObject spawnObstacle = Instantiate(Obstacle, spawnLocation, Quaternion.identity) as GameObject;

            //change scale 
            spawnObstacle.transform.localScale = spawnObstacle.transform.localScale * Random.Range(0.7f,1.5f);
>>>>>>> parent of c91bd13... Merge branch 'master' of https://github.com/CaiCoding2/Monkey-Mayhem
        }
    }
   /* public void spawn()
    {
        Vector2 spawnPosition = new Vector2(0, 0);
        bool spawnable = false;

        int safenet = 0;

        while (!spawnable)
        {
            float spwanPosX = Random.Range(-CamSize.x, CamSize.x);
            float spawnPosY = CamSize.y;

            spawnPosition = new Vector2(spwanPosX, spawnPosY);
            spawnable = PreventOverlap(spawnPosition);
            if (spawnable)
            {
                break;
            }
            safenet++;
            if (safenet > 40)
            {
                break;
                Debug.Log("Too Many");
            }
        }
        GameObject newObstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity) as GameObject;
    }

    bool PreventOverlap(Vector2 spawnpos)
    {
        colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, Vector2.Angle(Vector2.zero, transform.position), mask);

        for (int i =0; i < colliders.Length; i++)
        {
            Vector2 center = colliders[i].bounds.center;

            float width = colliders[i].bounds.extents.x;
            float height= colliders[i].bounds.extents.y;

            float leftExtent = center.x - width;
            float RightExtent = center.x + width;
            float bottomExtent = center.x - height;
            float topExtent = center.x + height;

            if(spawnpos.x >= leftExtent && spawnpos.x <= RightExtent)
            {
                if(spawnpos.y >= bottomExtent && spawnpos.y <= topExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }*/

}
