using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ��¥: 2022.05.26
 * �ۼ���: ���ؿ� (Park JunWoo)
 * 
 * ĳ���� ����â���� ĳ������ ȸ���� ����ϰ� �ִ� ��ũ��Ʈ
 */

public class AnimalsRotate : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
}
