using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySetings : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject _player;
    public Transform   target;

    List<Transform> _target = new List<Transform>();

    private int irandomTarget;

    private float Distance;
    public float agarDistance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        foreach(Transform Target in target.GetComponentInChildren<Transform>())
        {
            _target.Add(Target);
        }
        
    }

    private void Update()
    {
        
        /*if(agent.destination =)
        {
        irandomTarget = Random.Range(0,_r)
        }*/
    }
    void Idle()
    {

    }

    void Agar()
    {
       //agent.SetDestination(_target.position);
    }

    void Dead()
    {

    }
}
