using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMotion : MonoBehaviour
{
    //Asteroid Movement
    private float _minSpinSpeed = 1f;
    private float _maxSpinSpeed = 5f;
    private float _minThrust = 0.1f;
    private float _maxThrust = 0.5f;
    private float _spinSpeed;

    void Start()
    {
        SetMotion();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, _spinSpeed * Time.deltaTime);
    }

    void SetMotion()
    {
        _spinSpeed = Random.Range(_minSpinSpeed, _maxSpinSpeed);
        float thrust = Random.Range(_minThrust, _maxThrust);

        Rigidbody asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    }

}
