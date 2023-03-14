using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;

    private List<GameObject> _pooledObjects = new List<GameObject>();
    private int _amountToPool = 15;

    private void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_laserPrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; ++i)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }

}
