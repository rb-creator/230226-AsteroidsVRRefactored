
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour
{

    //Movement Management Variables
    public string surgeControl = "XRI_Left_Primary2DAxis_Vertical";
    [SerializeField] private string rollControl = "XRI_Left_Primary2DAxis_Horizontal";
    [SerializeField] private string pitchControl = "XRI_Right_Primary2DAxis_Vertical";
    [SerializeField] private string yawControl = "XRI_Right_Primary2DAxis_Horizontal";
    [SerializeField] private string boostButton = "XRI_Right_PrimaryButton";
    
    private float surgeInput;
    private float rollInput;
    private float pitchInput;
    private float yawInput;

    [SerializeField] private float thrustSpeed = 1600f;
    [SerializeField] private float boostSpeed = 10000f;
    [SerializeField] private float rotateSpeed = 0.5f;

    [SerializeField] private Rigidbody rocketBody;

    private void Awake()
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
        rocketBody.AddForce(transform.forward * Time.deltaTime * -thrustSpeed * surgeInput);
        rocketBody.AddTorque(transform.forward * Time.deltaTime * -rotateSpeed * rollInput);
        rocketBody.AddTorque(transform.right * Time.deltaTime * rotateSpeed * pitchInput);
        rocketBody.AddTorque(transform.up * Time.deltaTime * rotateSpeed * yawInput);

        SpeedBoost();
    }

    void SpeedBoost()
    {
        if (Input.GetButton(boostButton))
        {
            rocketBody.AddForce(transform.forward * Time.deltaTime * boostSpeed);
        }
    }

    private void Update()
    {

    }
}
     
        
