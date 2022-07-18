using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [SerializeField]
    GameObject poolingObjectPrefab;

    Queue<Bullet> objQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;
        Initialized(10);
    }
    private void Initialized(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            objQueue.Enqueue(CreateObject());
        }
    }

    Bullet CreateObject()
    {
        Bullet newObject = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(transform);
        return newObject;
    }
    public static Bullet GetBullet()
    {
        if(Instance.objQueue.Count> 0)
        {
            Bullet obj = Instance.objQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        Bullet newObject = Instance.CreateObject();
        newObject.transform.SetParent(null);
        newObject.gameObject.SetActive(true);
        return newObject;
    }

    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.objQueue.Enqueue(obj);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
