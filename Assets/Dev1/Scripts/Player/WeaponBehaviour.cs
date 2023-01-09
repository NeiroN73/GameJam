using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Camera _camera;

    private Weapon _currentWeapon;

    private Dictionary<ItemType, Weapon> _weaponDictionary;

    private void Start()
    {
        _currentWeapon = GetComponent<CakeCatapult>();

        _inputSystem = GetComponent<InputSystem>();
        _camera = Camera.main;

        _inputSystem.OnLeftMouseClick += OnAttack;

        _weaponDictionary = new()
        {
            { ItemType.Weapon1, GetComponent<CakeCatapult>() },
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

        _currentWeapon.Attack();
    }
}
