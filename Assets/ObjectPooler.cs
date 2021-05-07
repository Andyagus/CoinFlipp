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
        public GameObject imageSprite;
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
                GameObject obj = Instantiate(pool.imageSprite);
                obj.transform.SetParent(parentPanel.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);

        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        objectToSpawn = poolDictionary[tag].Dequeue();


        if (objectToSpawn.tag == "Untagged")
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.gameObject.tag = "active";
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

        }



        return null;
    }


    public void ReturnToPool(string tag, Vector3 position, Quaternion rotation)
        
    {
        //var visibleObjs = parentPanel.FindGameObjectsWithTag("active");

        //foreach(Transform child in parentPanel.transform)
        //{
        //    if (child.tag == "active")
        //    {
        //        var children = child.tag = "Untagged";

        //        //children.gameObject.SetActive(false);
        //    }
            
            
        //}
        
        //Debug.Log(visibleObjs);
        //foreach(GameObject visible in visibleObjs)
        //{
        //    visible.transform.position = position;
        //    visible.transform.rotation = rotation;

        //    visible.SetActive(false);
        //    Debug.Log(visible);
        //    visible.gameObject.tag = null;

        //}
    }

}