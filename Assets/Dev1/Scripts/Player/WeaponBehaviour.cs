using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private InputSystem _inputSystem;

    private Weapon _currentWeapon;

    private Dictionary<ItemType, Weapon> _weaponDictionary;

    private void Start()
    {
        _currentWeapon = GetComponent<HandGun>();

        _inputSystem = GetComponent<InputSystem>();

        _inputSystem.OnLeftMouseClick += OnAttack;

        _weaponDictionary = new()
        {
            { ItemType.Weapon1, GetComponent<HandGun>() },
            { ItemType.Weapon2, GetComponent<Melee>() },
        };
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            foreach(KeyValuePair<ItemType, Weapon> weapon in _weaponDictionary)
            {
                if(item.Weapon.ItemType == weapon.Key)
                {
                    _currentWeapon = weapon.Value;
                }
            }

            Destroy(item.gameObject);
        }
    }

    private void OnAttack()
    {
        _currentWeapon.Attack();
    }
}
