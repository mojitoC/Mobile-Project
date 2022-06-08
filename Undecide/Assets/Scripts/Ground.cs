using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Vector3 movespeed;
    private float width;

    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update

    private void Start()
    {
        movespeed = Vector3.back * 0.1f;
        
        BoxCollider backgroundCollider = GetComponent<BoxCollider>();
        width = backgroundCollider.size.z + 5f;
        timeAfterSpawn = 0f;
        spawnRate = 5f;
    }
    public void DestroyGround()    //사용이 끝난 총알을 오브젝트 풀에 반환 시킴
    {
        ObjectPool.ReturnBackground(this);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.isGameStart)       //
        {
            timeAfterSpawn += Time.deltaTime;
            transform.Translate(movespeed);
            


            if (timeAfterSpawn >= spawnRate && transform.position.z <= -width)
            {
                timeAfterSpawn = 0f;
                
                ObjectPool.GetBackground();
                Invoke("DestroyGround", 3f);
                //DestroyGround();
            }
        }
    }
}
