using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateAmmunition : MonoBehaviour
{
    [Tooltip(" health")]
    public int Health = 100;

    private int _damage;

    private EnemySeting _enemy;
    private DeathOptions _death;



    public void Awake()
    {
        _enemy = GetComponent<EnemySeting>();
        _death = GetComponent<DeathOptions>();
    }
    public void Hit(int hit, GameObject target)
    {

        Health -= hit;
        _enemy.Reaction();
        _enemy._player = target;
        if (Health <= 0)
        {
            _death.SacleDead();
        }

    }
    public void Attack()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            
        }
    }
}
