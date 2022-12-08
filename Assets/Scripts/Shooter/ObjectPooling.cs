using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject poolGameObject;
    public int numObjectsOnStart;

    private List<GameObject> poolObjects = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < numObjectsOnStart; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject objects = Instantiate(poolGameObject);
        objects.SetActive(false);
        poolObjects.Add(objects);
        return objects;
    }
    public GameObject GetObject()
    {
        GameObject objects = poolObjects.Find(x => x.activeInHierarchy == false);
        if (objects == null)
        {
            objects = CreateNewObject();
        }
        objects.SetActive(true);
        return objects;
    }
}
