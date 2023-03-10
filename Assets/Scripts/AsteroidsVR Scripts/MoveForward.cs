using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float _speed = 1500f;
    private Rigidbody _rb;
    private Rigidbody _rocketRb;

    private void Awake()
    {
        _rb =  GetComponent<Rigidbody>();
        _rocketRb = GameObject.Find("Rocket").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        SetLaserVelocity();
    }

    private void SetLaserVelocity()
    {
        _rb.velocity = _rocketRb.velocity + (transform.forward * Time.deltaTime * _speed);
    }
}

