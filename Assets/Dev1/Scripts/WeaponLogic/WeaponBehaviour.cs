using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Camera _camera;
    private PlayerAnimator _playerAnimator;

    private Weapon _currentWeapon;
    private Item _currentItem;

    private Dictionary<ItemType, Weapon> _weaponDictionary;

    private float _rotationVelocity = 0;

    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();
        _camera = Camera.main;
        _playerAnimator = GetComponent<PlayerAnimator>();

        _inputSystem.OnLeftMouseClick += OnAttack;

        _weaponDictionary = new()
        {
            { ItemType.Hammer, GetComponent<Hammer>() },
            { ItemType.Crossbow, GetComponent<Crossbow>() },
            { ItemType.Mop, GetComponent<Mop>() }
        };
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            TakeItem(item);
        }
    }

    private void TakeItem(Item item)
    {
        if (_currentWeapon)
        {
            _currentWeapon.CurrentWeaponModel.SetActive(false);
            DropItem(_currentItem);
        }
        
        foreach (KeyValuePair<ItemType, Weapon> weapon in _weaponDictionary)
        {
            if (item.DataItemSO.ItemType == weapon.Key)
            {
                _currentWeapon = weapon.Value;
                _currentItem = item;
                _currentWeapon.CurrentWeaponModel.SetActive(true);
                _playerAnimator.ItemType = _currentItem.DataItemSO.ItemType;
            }
        }
        
        Destroy(item.gameObject);
    }

    private void DropItem(Item item)
    {
        Instantiate(item.DataItemSO.ItemPrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);
        //item.ThrowUp();
    }

    private void OnAttack(Vector3 mousePosition)
    {
        if (_currentWeapon == null)
            return;

        Vector3 direction = _inputSystem.GetDirectionMouse();
        float _targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                          _camera.transform.eulerAngles.y;
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, 0);
        transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);

        _currentWeapon.PlayAnimation();
    }
}
