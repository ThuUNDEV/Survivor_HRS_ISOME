using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;

    private static List<GameObject> _objectList = new List<GameObject>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public static GameObject Instance(GameObject objectSource)
    {
        GameObject objectResult = null;

        foreach (GameObject gameObject in _objectList)
        {
            if (!gameObject.activeInHierarchy)
            {
                objectResult = gameObject;
                break;
            }
        }

        if (objectResult == null)
        {
            objectResult = Instantiate(objectSource);
            _objectList.Add(objectResult);
        }

        objectResult.SetActive(true);

        return objectResult;
    }

    public static void PushToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
