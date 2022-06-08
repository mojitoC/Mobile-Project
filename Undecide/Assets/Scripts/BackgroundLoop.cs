using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    
    private float width; // 배경의 가로길이
    public float moveSpeed = 10f;
    public float distance = 5f;
    private void Awake()
    {
        BoxCollider backgroundCollider = GetComponent<BoxCollider>();
        width = backgroundCollider.size.z * distance;
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

    }


    private void Reposition() 
    {
        Vector3 offset = new Vector3(0, 0, width * 7f);
        transform.position = transform.position + offset;
    }
}
