using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Player _player;

    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private int _cameraMovementSpeed;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        Vector3 cameraPosition = new Vector3(
            _player.transform.position.x + _cameraOffset.x, _player.transform.position.y + _cameraOffset.y, _player.transform.position.z + _cameraOffset.z);

        transform.position = Vector3.Lerp(transform.position, cameraPosition, _cameraMovementSpeed * Time.deltaTime);
    }
}
