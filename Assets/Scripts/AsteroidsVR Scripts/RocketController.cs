
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    //Movement Management Variables
    [SerializeField] private string surgeControl = "XRI_Left_Primary2DAxis_Vertical";
    [SerializeField] private string rollControl = "XRI_Left_Primary2DAxis_Horizontal";
    [SerializeField] private string pitchControl = "XRI_Right_Primary2DAxis_Vertical";
    [SerializeField] private string yawControl = "XRI_Right_Primary2DAxis_Horizontal";
    [SerializeField] private string boostButton = "XRI_Right_PrimaryButton";
    private float surgeInput;
    private float rollInput;
    private float pitchInput;
    private float yawInput;
    [SerializeField] private float _thrustSpeed = 1500f;
    [SerializeField] private float _boostSpeed = 10000f;
    [SerializeField] private float _rotateSpeed = 0.5f;
    
    private Rigidbody _rocketRb;

    private void Awake()
    {
        _rocketRb =  GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Reference XR Controls
        surgeInput = Input.GetAxis(surgeControl);
        rollInput = Input.GetAxis(rollControl);
        pitchInput = Input.GetAxis(pitchControl);
        yawInput = Input.GetAxis(yawControl);
    }

    private void FixedUpdate()
    {
        //Addforce and Torque
        _rocketRb.AddForce(transform.forward * Time.deltaTime * -_thrustSpeed * surgeInput);
        _rocketRb.AddTorque(transform.forward * Time.deltaTime * -_rotateSpeed * rollInput);
        _rocketRb.AddTorque(transform.right * Time.deltaTime * _rotateSpeed * pitchInput);
        _rocketRb.AddTorque(transform.up * Time.deltaTime * _rotateSpeed * yawInput);

        //Speedboost
        if (Input.GetButton(boostButton))
        {
            SpeedBoost();
            //Debug.Log("Primary Button Pressed");
        }
    }

    void SpeedBoost()
    {
        _rocketRb.AddForce(transform.forward * Time.deltaTime * _boostSpeed);
    }

}
     
        
