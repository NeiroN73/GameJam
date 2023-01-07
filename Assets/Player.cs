using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputSystem _inputSystem = new();
    private Rigidbody _rigidbody;
    private Camera _camera;

    [SerializeField] private int _movementSpeed;
    [SerializeField] private int _rotationSpeed;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private int _cameraMovementSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    private void Move()
    {
        Vector3 direction = _inputSystem.GetDirectionMove().normalized;
        _rigidbody.velocity += direction * _movementSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector3 direction = _inputSystem.GetDirectionMove().normalized;

        if (direction.x == 0 && direction.z == 0)
            return;

        transform.rotation = Quaternion.Lerp(
            transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);
    }

    private void CameraMove()
    {
        Vector3 cameraPosition = new Vector3(
            transform.position.x + _cameraOffset.x, transform.position.y + _cameraOffset.y, transform.position.z + _cameraOffset.z);

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, cameraPosition, _cameraMovementSpeed * Time.deltaTime);
    }
}