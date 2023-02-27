
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    //Movement Management Variables
    private string surgeControl = "XRI_Left_Primary2DAxis_Vertical";
    private string rollControl = "XRI_Left_Primary2DAxis_Horizontal";
    private string pitchControl = "XRI_Right_Primary2DAxis_Vertical";
    private string yawControl = "XRI_Right_Primary2DAxis_Horizontal";
    private string boostButton = "XRI_Right_PrimaryButton";
    //private string hideButton = "XRI_Left_PrimaryButton";
    private float surgeInput;
    private float rollInput;
    private float pitchInput;
    private float yawInput;
    public float thrustSpeed = 1600f;
    public float boostSpeed = 20000f;
    public float rotateSpeed = 0.5f;
    public Rigidbody rocketBody;
    //public GameObject leftMesh;
    //public GameObject rightMesh;
    //public bool meshVisible = true;


    private void FixedUpdate()
    {
        //Reference XR Controls
        surgeInput = Input.GetAxis(surgeControl);
        rollInput = Input.GetAxis(rollControl);
        pitchInput = Input.GetAxis(pitchControl);
        yawInput = Input.GetAxis(yawControl);

        //Addforce and Torque
        rocketBody.AddForce(transform.forward * Time.deltaTime * -thrustSpeed * surgeInput);
        rocketBody.AddTorque(transform.forward * Time.deltaTime * -rotateSpeed * rollInput);
        rocketBody.AddTorque(transform.right * Time.deltaTime * rotateSpeed * pitchInput);
        rocketBody.AddTorque(transform.up * Time.deltaTime * rotateSpeed * yawInput);

        //Speedboost
        if (Input.GetButton(boostButton))
        {
            rocketBody.AddForce(transform.forward * Time.deltaTime * boostSpeed);

            //Debug.Log("Primary Button Pressed");
        }
    }

    private void Update()
    {
        //if (Input.GetButtonDown(hideButton) && meshVisible == true)
        //{
        //    leftMesh.SetActive(false);
        //    rightMesh.SetActive(false);
        //    meshVisible = false;
        //}
        //else
        //{
        //    if (Input.GetButtonDown(hideButton) && meshVisible == false)
        //    {
        //        leftMesh.SetActive(true);
        //        rightMesh.SetActive(true);
        //        meshVisible = true;
        //    }
        //}
    }
}
     
        
