using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : Weapon
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPointBullet;
    public override void Attack()
    {
        Vector3 mousePosition = Input.mousePosition;
        Instantiate(_bulletPrefab, _spawnPointBullet.position - mousePosition, Quaternion.identity);
    }
}
