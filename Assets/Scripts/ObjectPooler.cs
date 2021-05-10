using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private GameObject objectToSpawn;
    [SerializeField] GameObject parentPanel;

    //private Queue<GameObject> objectPool;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject imagePrefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools; 

    public Dictionary<string, Queue<GameObject>> poolDictionary;


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.imagePrefab);
                obj.transform.SetParent(parentPanel.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                Debug.Log(i);
            }
             
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;


        var poolCount = poolDictionary[tag].Count;
        Debug.Log(poolCount);
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }


    public void ReturnToPool(string tag)

    {
        foreach(GameObject obj in poolDictionary[tag])
        {
            obj.SetActive(false);
            Debug.Log(obj);
        }
    }

}