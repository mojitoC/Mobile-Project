using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 날짜: 2022.05.26
 * 작성자: 박준우 (Park JunWoo)
 * 
 * 캐릭터 선택창에서 캐릭터의 회전을 담당하고 있는 스크립트
 */

public class AnimalsRotate : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
}
