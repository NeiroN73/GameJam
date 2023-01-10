using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CakeCatapult : Weapon
{
    [SerializeField] private Bullet _cakePrefab;
    [SerializeField] private Transform _spawnPointCake;
    [SerializeField] private float _dropForce;
    [SerializeField] private float _heightDrop;

    private void Start()
    {
        playerAnimator.OnEndAnimCakeThrowed += Attack;
    }

    public override void PlayAnimation()
    {
        //Vector3 direction = transform.forward;
        //Bullet bullet = Instantiate(_cakePrefab, _spawnPointCake.position, Quaternion.identity);
        //bullet.Initialize(new Vector3(direction.x, _heightDrop, direction.z), _dropForce);
        playerAnimator.OnAnimThrowCake();
    }

    public void Attack()
    {
        print("cakeAttack");
    }
}
