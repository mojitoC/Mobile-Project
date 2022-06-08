using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Vector3 moveSpeed;
    private float spawnRate;
    private float timeAfterSpawn;

    private float[] spawnPosition = new float[3] {-1.8f, 0, 1.8f };
    private Vector3 sP;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Vector3.back * 3f;
        timeAfterSpawn = 0f;
        spawnRate = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameStart)       //
        {
            timeAfterSpawn += Time.deltaTime;


            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;
                sP = new Vector3(spawnPosition[Random.Range(0, 3)], 0, 0);
                var bullet = ObjectPool.GetObject();
                bullet.transform.position = transform.position + Vector3.back;
                bullet.transform.position = transform.position + sP;
                bullet.Shoot();
            }
        }
    }


}
