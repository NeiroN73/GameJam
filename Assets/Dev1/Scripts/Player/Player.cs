using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Rigidbody _rigidbody;

    [SerializeField] private int _movementSpeed;
    [SerializeField] private int _rotationSpeed;
    [SerializeField] private int _jumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputSystem = GetComponent<InputSystem>();

        _inputSystem.OnSpacePressed += Jump;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();
        _rigidbody.velocity += direction * _movementSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();

        if (direction.x == 0 && direction.z == 0)
            return;

        transform.rotation = Quaternion.Lerp(
            transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        var ground = Physics.OverlapSphere(
            new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 1);

        if(ground.Length > 1)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
    }
}