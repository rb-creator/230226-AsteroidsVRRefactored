using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerNew : MonoBehaviour
{
    [SerializeField] private InputActionAsset XRIActions;
    InputActionMap _rightHandActionMap;
    InputActionMap _leftHandActionMap;
    InputAction _surgeInputAction;
    InputAction _rollInputAction;
    InputAction _pitchInputAction;
    InputAction _yawInputAction;
    InputAction _boostInputAction;

    [SerializeField] private float _surgeSpeed = 1500f;
    [SerializeField] private float _rotateSpeed = 0.5f;
    [SerializeField] private float _boostSpeed = 5000f;

    private Vector2 _surgeInput;
    private Vector2 _rollInput;
    private Vector2 _pitchInput;
    private Vector2 _yawInput;
    private float _boostInput;
    
    private Rigidbody _rocketRb;

    private void Awake()
    {
        _rocketRb = GetComponent<Rigidbody>();

        _leftHandActionMap = XRIActions.FindActionMap("XRI LeftHand RocketController");
        _rightHandActionMap = XRIActions.FindActionMap("XRI RightHand RocketController");

        _surgeInputAction = _leftHandActionMap.FindAction("SurgeControl");
        _rollInputAction = _leftHandActionMap.FindAction("RollControl");

        _boostInputAction = _rightHandActionMap.FindAction("Boost");
        _pitchInputAction = _rightHandActionMap.FindAction("PitchControl");
        _yawInputAction = _rightHandActionMap.FindAction("YawControl");

        _surgeInputAction.performed += context => _surgeInput = context.ReadValue<Vector2>();
        _surgeInputAction.canceled += context => _surgeInput = Vector2.zero;

        _rollInputAction.performed += context => _rollInput = context.ReadValue<Vector2>();
        _rollInputAction.canceled += context => _rollInput = Vector2.zero;

        _boostInputAction.performed += context => _boostInput = context.ReadValue<float>();
        _boostInputAction.canceled += context => _boostInput = context.ReadValue<float>();

        _pitchInputAction.performed += context => _pitchInput = context.ReadValue<Vector2>();
        _pitchInputAction.canceled += context => _pitchInput = Vector2.zero;

        _yawInputAction.performed += context => _yawInput = context.ReadValue<Vector2>();
        _yawInputAction.canceled += context => _yawInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _leftHandActionMap.Enable();
        _rightHandActionMap.Enable();
    }

    private void OnDisable()
    {
        _leftHandActionMap.Disable();
        _rightHandActionMap.Disable();
    }

    private void FixedUpdate()
    {
        ControlSurge();
        ControlRoll();
        SpeedBoost();
        ControlPitch();
        ControlYaw();
    }

    private void ControlSurge()
    {
        _rocketRb.AddForce(transform.forward * Time.deltaTime * _surgeSpeed * _surgeInput.y);
    }

    private void ControlRoll()
    {
        _rocketRb.AddTorque(transform.forward * Time.deltaTime * _rotateSpeed * _rollInput.x);
    }

    private void SpeedBoost()
    {
        _rocketRb.AddForce(transform.forward * Time.deltaTime * _boostInput * _boostSpeed);
    }

    private void ControlPitch()
    {
        _rocketRb.AddTorque(transform.right * Time.deltaTime * _rotateSpeed * _pitchInput.y);
    }

    private void ControlYaw()
    {
        _rocketRb.AddTorque(transform.up * Time.deltaTime * _rotateSpeed * _yawInput.x);
    }
}
