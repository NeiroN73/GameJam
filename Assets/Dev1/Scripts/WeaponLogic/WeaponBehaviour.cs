using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Camera _camera;

    private Weapon _currentWeapon;
    private Item _currentItem;

    private Dictionary<ItemType, Weapon> _weaponDictionary;

    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();
        _camera = Camera.main;

        _inputSystem.OnLeftMouseClick += OnAttack;

        _weaponDictionary = new()
        {
            { ItemType.Hammer, GetComponent<Hammer>() },
            { ItemType.Crossbow, GetComponent<Crossbow>() },
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
            }
        }
        
        Destroy(item.gameObject);
    }

    private void DropItem(Item item)
    {
        Instantiate(item.DataItemSO.ItemPrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
        //item.ThrowUp();
    }

    private void OnAttack(Vector3 mousePosition)
    {
        //Vector3 direction = _camera.ScreenToWorldPoint(mousePosition) - transform.position;
        //direction = new Vector3(0, direction.y, 0);
        //transform.LookAt(direction);

        //Vector3 mousePos = _camera.ScreenToWorldPoint(mousePosition);
        //Vector3 perpendicular = transform.position - mousePos;
        //perpendicular = new Vector3(0, perpendicular.y, 0);
        //transform.rotation = Quaternion.LookRotation(perpendicular);
        //print(mousePosition);
        if (_currentWeapon == null)
            return;

        _currentWeapon.PlayAnimation();
    }
}
