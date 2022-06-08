using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //�¿� �̵�
    private float move = 1.8f;  //1ȸ �̵� �Ÿ� movexWidth
    private float moveTime = 0.1f;
    private bool isMove = false;

    
    //Y�� �̵�
    /*
    private float originY = 0.55f;
    private float gravity = -9.81f;
    private float moveTimeY = 0.3f;
    */
    public static int jumpCount = 0;
    public float jumpForce = 300f;

    private bool isJump;
    
    
    
    
    

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void MoveToLR(int x)
    {
        if (isMove == true) return;

        if( x > 0 && transform.position.x < move )
        {
            StartCoroutine(OnMoveToLR(x));
        }
        else if(x < 0 && transform.position.x > -move )
        {
            StartCoroutine(OnMoveToLR(x));
        }
    }
    
    public void MoveToY()
    {
        if (isJump == true) return;
            StartCoroutine(OnMoveToY());
  
    }
    

    private IEnumerator OnMoveToLR(int direction) 
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * move;

        isMove = true;

        while (percent < 1) 
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }

        isMove = false;
    }
    
    private IEnumerator OnMoveToY() 
    {
        isJump = true;
        jumpCount++; //����Ƚ�� ����
        rb.velocity = Vector3.zero; //���� ���� �ӵ��� ���������� ���η� ����
        rb.AddForce(new Vector3(0, jumpForce, 0)); //���� ����

        
        /*
        float current = 0;
        float percent = 0;
        float v0 = -gravity;

        while (percent < 1) 
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;

            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y+10f, transform.position.z);

            
        }*/

        isJump = false;
        rb.useGravity = true;
        yield return null;
    }
        

    }
