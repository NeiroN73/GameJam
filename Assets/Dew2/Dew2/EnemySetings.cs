using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySetings : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject _player;
    public Transform  target;

    List<Transform> _target = new List<Transform>();

    public int randomTarget, randomAct;// рандомные числа randomTarget-куда идти randomAct - действие


    private float distance,trargetDistance;
    public float agarDistance;
    
    public float time,timer = 15;//таймер

    public bool wait;//ожидание 


    private void Awake()
    {
        
        time = timer;
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        foreach(Transform Target in target.GetComponentInChildren<Transform>())//добавить в list
        {
            _target.Add(Target);
        }
        
    }

    private void FixedUpdate()
    {
        //действие при условии distance
        distance = Vector3.Distance(agent.transform.position, _player.transform.position);
        if (distance <= agarDistance)
        {
            
            Agar();
        }
        else
        {
            trargetDistance = Vector3.Distance(agent.transform.position, _target[randomTarget].position);
            Idle();
        }
    }


    void Idle()
    {
        if(trargetDistance > 3  )
        {
            agent.SetDestination(_target[randomTarget].position);
        }
        else
        {
            //randomAct = Random.Range(0, 1);
            switch (randomAct)
            {
                case 1:
                    randomTarget = Random.Range(0, _target.Count);
                    break;
                case 0:
                    time -= Time.deltaTime * 2;
                    if(time <= 1)
                    {
                        randomTarget = Random.Range(0, _target.Count);
                        time = timer;
                        
                    }
                    break;
            }
        }
        
    }

    void Agar()
    {
        agent.SetDestination(_player.transform.position);
    }

    void Dead()
    {

    }
}
