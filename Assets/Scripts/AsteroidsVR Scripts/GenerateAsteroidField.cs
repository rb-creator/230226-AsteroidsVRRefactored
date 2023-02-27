using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{

    public Transform asteroidPrefab;
    public GameObject fieldCentre;
    public int fieldRadius = 1000;
    public int asteroidCount = 500;

    private Vector3 fieldCentrePos;

    private void Awake()
    {
        fieldCentrePos = fieldCentre.transform.position;
    }

    void Start()
    {
        for (int loop = 0; loop < asteroidCount; loop++)
        {
            Transform tempAsteroid = Instantiate(asteroidPrefab, fieldCentrePos + Random.insideUnitSphere * fieldRadius, Random.rotation);
            tempAsteroid.localScale = tempAsteroid.localScale * Random.Range(0.5f, 5);
        }
    }
}

