using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject objectToPool, initialCloud;
    [SerializeField] int initialAmount;
    [SerializeField] List<GameObject> objectPoolList;
    [SerializeField] float timeToSpawn;
    float currentTime;
    [SerializeField] Transform pointToSpawn;

    bool canGenerateClouds;

    // Start is called before the first frame update
    void Start()
    {
        canGenerateClouds = true;
        currentTime = timeToSpawn;
        for (int i = 0; i < initialAmount; i++)
        {
            CreateNewObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canGenerateClouds)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                objectToPool = GetObject();
                objectToPool.transform.position = pointToSpawn.transform.position;
                objectToPool.transform.rotation = pointToSpawn.transform.rotation;
                objectToPool.SetActive(true);
                currentTime = timeToSpawn;
            }
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject objects = Instantiate(objectToPool);
        objects.SetActive(false);
        objectPoolList.Add(objects);
        return objects;
    }
    public GameObject GetObject()
    {
        GameObject objects = objectPoolList.Find(x => x.activeInHierarchy == false);
        if (objects == null)
        {
            objects = CreateNewObject();
        }
        objects.SetActive(true);
        return objects;
    }

    public void StopGenerating()
    {
        initialCloud.SetActive(false);
        canGenerateClouds = false;
    }
}
