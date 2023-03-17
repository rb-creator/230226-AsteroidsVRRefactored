using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerNew : MonoBehaviour
{
    [SerializeField] private InputActionAsset _xRIActions;
    InputAction _surgeAction;
    InputAction _rollAction;
    InputAction _pitchAction;
    InputAction _yawAction;
    InputAction _boostAction;

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

        _surgeAction = _xRIActions.FindActionMap("XRI LeftHand RocketController").FindAction("SurgeControl");
        _rollAction = _xRIActions.FindActionMap("XRI LeftHand RocketController").FindAction("RollControl");

        _boostAction = _xRIActions.FindActionMap("XRI RightHand RocketController").FindAction("Boost");
        _pitchAction = _xRIActions.FindActionMap("XRI RightHand RocketController").FindAction("PitchControl");
        _yawAction = _xRIActions.FindActionMap("XRI RightHand RocketController").FindAction("YawControl");

        _surgeAction.performed += context => _surgeInput = context.ReadValue<Vector2>();
        _surgeAction.canceled += context => _surgeInput = Vector2.zero;

        _rollAction.performed += context => _rollInput = context.ReadValue<Vector2>();
        _rollAction.canceled += context => _rollInput = Vector2.zero;

        _boostAction.performed += context => _boostInput = context.ReadValue<float>();
        _boostAction.canceled += context => _boostInput = context.ReadValue<float>();

        _pitchAction.performed += context => _pitchInput = context.ReadValue<Vector2>();
        _pitchAction.canceled += context => _pitchInput = Vector2.zero;

        _yawAction.performed += context => _yawInput = context.ReadValue<Vector2>();
        _yawAction.canceled += context => _yawInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _xRIActions.FindActionMap("XRI LeftHand RocketController").Enable();
        _xRIActions.FindActionMap("XRI RightHand RocketController").Enable();
    }

    private void OnDisable()
    {
        _xRIActions.FindActionMap("XRI LeftHand RocketController").Disable();
        _xRIActions.FindActionMap("XRI RightHand RocketController").Disable();
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
