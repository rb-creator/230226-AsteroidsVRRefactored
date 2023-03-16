using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandModelToggle : MonoBehaviour
{
    [SerializeField] InputActionReference _handModelToggle;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject _rightController;

    private int _state = 0;

    private void OnEnable()
    {
        _handModelToggle.action.performed += SwitchHandModels;
    }

    private void OnDisable()
    {
        _handModelToggle.action.performed -= SwitchHandModels;
    }

    private void Start()
    {
        _leftHand.SetActive(false);
        _rightHand.SetActive(false);
        _leftController.SetActive(true);
        _rightController.SetActive(true);
    }

    void SwitchHandModels(InputAction.CallbackContext obj)
    {
        switch (_state)
        {
            case 0:
                _leftHand.SetActive(true);
                _rightHand.SetActive(true);
                _leftController.SetActive(false);
                _rightController.SetActive(false);
                _state++;
                break;
            case 1:
                _leftHand.SetActive(false);
                _rightHand.SetActive(false);
                _leftController.SetActive(false);
                _rightController.SetActive(false);
                _state++;
                break;
            case 2:
                _leftHand.SetActive(false);
                _rightHand.SetActive(false);
                _leftController.SetActive(true);
                _rightController.SetActive(true);
                _state = 0;
                break;
        }
    }

}
