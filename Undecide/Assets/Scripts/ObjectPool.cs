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

    private Bundle CreateNewObject()    //새로운 장애물을 만들어내는 함수, 
    {                                   //오브젝트 풀안의 모든 오브젝트를 빌린 상태일때 사용
        var newObj = Instantiate(poolingObjectPrefab[Random.Range(0,poolingObjectPrefab.Length)], transform).GetComponent<Bundle>();
        newObj.gameObject.SetActive(false);
        return newObj;
    } 
    private Ground CreateNewBackground()    //새로운 배경을 만들어내는 함수, 
    {                                   //오브젝트 풀안의 모든 오브젝트를 빌린 상태일때 사용
        var newBg = Instantiate(poolingBackgroundPrefab[Random.Range(0,poolingBackgroundPrefab.Length)], transform).GetComponent<Ground>();
        newBg.gameObject.SetActive(false);
        return newBg;
    }



    private void Initialize(int count)      //매개변수로 받은 수만큼 미리 풀링할 오브젝트를 생성할 역할
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
            poolingBackgroundQueue.Enqueue(CreateNewBackground());
        }
    }

    private void Initialize2(int count)      //매개변수로 받은 수만큼 미리 풀링할 오브젝트를 생성할 역할
    {
        for (int i = 0; i < count; i++)
        {
            
            poolingBackgroundQueue.Enqueue(CreateNewBackground());
        }
    }

    public static Bundle GetObject()        //오브젝트 풀에서 오브젝트를 빌려갈 때 사용할 함수
    {
        if (Instance.poolingObjectQueue.Count > 0)       //빌려줄 오브젝트가 있을 때와 없을때로 나눔 
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

    public static void ReturnObject(Bundle Bundle)      //빌려줬던 오브젝트를 돌려받는 리턴 함수
    {
        Bundle.gameObject.SetActive(false);
        Bundle.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(Bundle);
    }       


    public static Ground GetBackground()        //오브젝트 풀에서 오브젝트를 빌려갈 때 사용할 함수
    {
        if (Instance.poolingBackgroundQueue.Count > 0)       //빌려줄 오브젝트가 있을 때와 없을때로 나눔 
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

    public static void ReturnBackground(Ground ground)      //빌려줬던 오브젝트를 돌려받는 리턴 함수
    {
        ground.gameObject.SetActive(false);
        ground.transform.SetParent(Instance.transform);
        Instance.poolingBackgroundQueue.Enqueue(ground);
    }               

}
