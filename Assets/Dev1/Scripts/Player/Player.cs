using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Rigidbody _rigidbody;
    private CharacterController _controller;
    private Camera _camera;
    [SerializeField] private CinemachineVirtualCamera _cinemachine;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;

    public int Health;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputSystem = GetComponent<InputSystem>();
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main;

        _inputSystem.OnSpacePressed += Jump;


        _cinemachineTargetYaw = _cameraTarger.transform.rotation.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {

        //Rotate();
        Move();
    }

    private void LateUpdate()
    {
        
        CameraRotation();
    }

    private void Jump()
    {
        var ground = Physics.OverlapSphere(
            new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 1);

        if(ground.Length > 1)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z); //может быть баг из за разного фпс

    }

    [SerializeField] private float _sensitivity;
    [SerializeField] private float _borderMouseMin;
    [SerializeField] private float _borderMouseMax;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    [SerializeField] private Transform _cameraTarger;

    private float _rotationVelocity;

    private void CameraRotation()
    {
        Vector2 direction = _inputSystem.GetDirectionMouse();
        _cinemachineTargetYaw += direction.x * _sensitivity;
        _cinemachineTargetPitch -= direction.y * _sensitivity;
        

        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _borderMouseMin, _borderMouseMax);

        _cameraTarger.rotation = Quaternion.Euler(_cinemachineTargetPitch + 0,
            _cinemachineTargetYaw, 0.0f);
    }

    private float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Move()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();

        if (direction == Vector3.zero)
            return;

        float _targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                                  _camera.transform.eulerAngles.y;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
            _rotationSpeed);

        transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        _rigidbody.velocity += targetDirection * _movementSpeed * Time.deltaTime;
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            print("Game over");
        }
    }
}