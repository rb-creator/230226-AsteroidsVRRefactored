using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControllerToggle : MonoBehaviour
{
  

    private string toggleButton = "XRI_Left_PrimaryButton";
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftController;
    public GameObject rightController;

    public bool handsVisible;
    public bool controllersVisible;

    int state = 0;


    void Start()
    {
        leftHand.SetActive(false);
        rightHand.SetActive(false);
        handsVisible = false;
        leftController.SetActive(true);
        rightController.SetActive(true);
        controllersVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown(toggleButton))
        {
            SwitchHandModels();
        }

    }

    void SwitchHandModels()
    {
        switch (state)
        {
            case 0:
                leftHand.SetActive(true);
                rightHand.SetActive(true);
                handsVisible = true;
                leftController.SetActive(false);
                rightController.SetActive(false);
                controllersVisible = false;
                state++;
                break;
            case 1:
                leftHand.SetActive(false);
                rightHand.SetActive(false);
                handsVisible = false;
                leftController.SetActive(false);
                rightController.SetActive(false);
                controllersVisible = false;
                state++;
                break;
            case 2:
                leftHand.SetActive(false);
                rightHand.SetActive(false);
                handsVisible = false;
                leftController.SetActive(true);
                rightController.SetActive(true);
                controllersVisible = true;
                state = 0;
                break;
        }
    }
}
