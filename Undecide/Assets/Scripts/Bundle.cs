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
    private void DestroyBullet()    //����� ���� �Ѿ��� ������Ʈ Ǯ�� ��ȯ ��Ŵ
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
                Debug.Log("�浹");
                playerController.OnDamage();
                
                
            }
        }
    }


}
