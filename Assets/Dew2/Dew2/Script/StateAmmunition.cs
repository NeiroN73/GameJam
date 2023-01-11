using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateAmmunition : MonoBehaviour
{
    [Tooltip(" health")] 
    public int Health = 100;

    private EnemySeting _enemy;

    public void Awake()
    {
        _enemy = GetComponent<EnemySeting>();
    }
    public void Hit(int hit, Transform target)
    {
        Health -= hit;
        _enemy.Reaction(target);
        if(Health<=0)
        {
            _enemy.Dead();
        }

    }
       
}
