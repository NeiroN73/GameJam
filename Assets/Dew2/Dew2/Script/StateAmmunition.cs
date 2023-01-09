using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateAmmunition : MonoBehaviour
{
    [Tooltip(" health")] 
    public int Health = 100;

    private EnemySeting _enemy;

    public void Hit(int hit, GameObject player)
    {
        _enemy.Dead();
        Health -= hit;
        if(Health<=0)
        {
            _enemy.Dead();
        }

    }
       
}
