using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private static Animator animator; // 사용할 애니메이터 컴포넌트
    [SerializeField]
    private float dragDistance = 5.0f;
    private Vector3 touchStart;
    private Vector3 touchEnd;

    private Movement movement;

    public GameObject[] heart = new GameObject[2];
    public static int playerHealth;
    public static bool isdie = false;


    private Rigidbody playerRigidbody;
    

    
    public static bool isjump = true; //TRUE일 때 점프 중 FALSE 일때는 반대 
    public static bool isGrounded = true;

    private void Awake()
    {
        playerHealth = 2;
        movement = GetComponent<Movement>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameStart)//
        {
            OnMobilePlatform();
            animator.SetTrigger("Start");
            animator.SetBool("Grounded", isGrounded);
            
        }
    }

    private void OnMobilePlatform()
    {
       if (Input.touchCount == 0) return;
        
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved )
        {
            
            touchEnd = touch.position;
            OnDragXY();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            
            isGrounded = true;
            Movement.jumpCount = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
        isGrounded = false;
    }
    
    private void OnDragXY()
    {
        //터치 상태로 x축 드래그 범위가 dragDistance보다 클 때 
        if (Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance && PlayerController.isGrounded == true)
        {
            movement.MoveToLR((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }
                
        if (Input.touchCount ==1 && Movement.jumpCount < 2)
        {
            movement.MoveToY();
            return;
        }
        

    }

    public void Die()
    {
        animator.SetTrigger("Die");
        Time.timeScale = 0;
        isdie = true;
    }

    public void OnDamage() 
    {
        switch (playerHealth)
        {
            case 2:
                heart[1].SetActive(false);
                playerHealth--;
                break;
            case 1:
                heart[0].SetActive(false);
                Die();
                break;

        }
    }
}
