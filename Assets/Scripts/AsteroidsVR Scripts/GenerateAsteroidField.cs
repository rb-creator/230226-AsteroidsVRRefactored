using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{

    [SerializeField] private Transform _asteroidPrefab;
    [SerializeField] private int _fieldRadius = 500;
    [SerializeField] private int _asteroidCount = 100;
    private Vector3 _fieldCentrePos;

    private void Awake()
    {
        _fieldCentrePos = transform.position;
    }

    void Start()
    {
        for (int loop = 0; loop < _asteroidCount; loop++)
        {
            Transform tempAsteroid = Instantiate(_asteroidPrefab, _fieldCentrePos + Random.insideUnitSphere * _fieldRadius, Random.rotation);
            tempAsteroid.localScale = tempAsteroid.localScale * Random.Range(0.5f, 5);
        }
    }
}

