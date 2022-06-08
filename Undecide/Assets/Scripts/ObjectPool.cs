using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    
    [SerializeField]
    private GameObject[] poolingObjectPrefab;
    [SerializeField]
    private GameObject[] poolingBackgroundPrefab;

    private Queue<Bundle> poolingObjectQueue = new Queue<Bundle>();
    private Queue<Ground> poolingBackgroundQueue = new Queue<Ground>();


    private void Awake()
    {
        
        Instance = this;
        Initialize(5);
        Initialize2(5);
        
    }

    private Bundle CreateNewObject()    //���ο� ��ֹ��� ������ �Լ�, 
    {                                   //������Ʈ Ǯ���� ��� ������Ʈ�� ���� �����϶� ���
        var newObj = Instantiate(poolingObjectPrefab[Random.Range(0,poolingObjectPrefab.Length)], transform).GetComponent<Bundle>();
        newObj.gameObject.SetActive(false);
        return newObj;
    } 
    private Ground CreateNewBackground()    //���ο� ����� ������ �Լ�, 
    {                                   //������Ʈ Ǯ���� ��� ������Ʈ�� ���� �����϶� ���
        var newBg = Instantiate(poolingBackgroundPrefab[Random.Range(0,poolingBackgroundPrefab.Length)], transform).GetComponent<Ground>();
        newBg.gameObject.SetActive(false);
        return newBg;
    }



    private void Initialize(int count)      //�Ű������� ���� ����ŭ �̸� Ǯ���� ������Ʈ�� ������ ����
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
            poolingBackgroundQueue.Enqueue(CreateNewBackground());
        }
    }

    private void Initialize2(int count)      //�Ű������� ���� ����ŭ �̸� Ǯ���� ������Ʈ�� ������ ����
    {
        for (int i = 0; i < count; i++)
        {
            
            poolingBackgroundQueue.Enqueue(CreateNewBackground());
        }
    }

    public static Bundle GetObject()        //������Ʈ Ǯ���� ������Ʈ�� ������ �� ����� �Լ�
    {
        if (Instance.poolingObjectQueue.Count > 0)       //������ ������Ʈ�� ���� ���� �������� ���� 
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else 
        { 
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Bundle Bundle)      //������� ������Ʈ�� �����޴� ���� �Լ�
    {
        Bundle.gameObject.SetActive(false);
        Bundle.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(Bundle);
    }       


    public static Ground GetBackground()        //������Ʈ Ǯ���� ������Ʈ�� ������ �� ����� �Լ�
    {
        if (Instance.poolingBackgroundQueue.Count > 0)       //������ ������Ʈ�� ���� ���� �������� ���� 
        {
            var obj = Instance.poolingBackgroundQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else 
        { 
            var newObj = Instance.CreateNewBackground();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnBackground(Ground ground)      //������� ������Ʈ�� �����޴� ���� �Լ�
    {
        ground.gameObject.SetActive(false);
        ground.transform.SetParent(Instance.transform);
        Instance.poolingBackgroundQueue.Enqueue(ground);
    }               

}
