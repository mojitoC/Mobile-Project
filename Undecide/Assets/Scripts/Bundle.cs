using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bundle : MonoBehaviour
{
    private Rigidbody move;
 

    private void Start()
    {
        move = GetComponent<Rigidbody>();
    }
    public void Shoot()
    {
        Invoke("DestroyBullet", 15f);

    }
    private void DestroyBullet()    //사용이 끝난 총알을 오브젝트 풀에 반환 시킴
    {
        ObjectPool.ReturnObject(this);
        
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(moveSpeed);
        move.velocity= Vector3.back * 6.7f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                Debug.Log("충돌");
                playerController.OnDamage();
                
                
            }
        }
    }


}
