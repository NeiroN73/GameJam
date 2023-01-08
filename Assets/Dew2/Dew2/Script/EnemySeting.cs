using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject _player;
    public Transform target;

    List<Transform> _target = new List<Transform>();

    private  int _randomTarget, _randomAct;// рандомные числа _randomTarget-куда идти _randomAct - действие


    private float _distance, _trargetDistance;
    public float agarDistance;

    public float time, timer = 15;//таймер

    public bool fear;//страх


    private void Awake()
    {

        time = timer;
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        foreach (Transform Target in target.GetComponentInChildren<Transform>())//добавить в list
        {
            _target.Add(Target);
        }

    }

    private void FixedUpdate()
    {
        //действие при условии _distance
        _distance = Vector3.Distance(agent.transform.position, _player.transform.position);
        if (_distance <= agarDistance)
        {

            Agar();
        }
        else
        {
            _trargetDistance = Vector3.Distance(agent.transform.position, _target[_randomTarget].position);
            Idle();
        }
    }


    void Idle()
    {
        if (_trargetDistance > 3)
        {
            agent.SetDestination(_target[_randomTarget].position);
        }
        else
        {
            //_randomAct = Random.Range(0, 1);
            switch (_randomAct)
            {
                case 1:
                    _randomTarget = Random.Range(0, _target.Count);
                    break;
                default:
                    time -= Time.deltaTime * 2;
                    if (time <= 1)
                    {
                        _randomTarget = Random.Range(0, _target.Count);
                        time = timer;

                    }
                    break;
            }
        }

    }

    void Agar()
    {
        switch (fear)
        {
            case false:
        agent.SetDestination(_player.transform.position);
                break;
            case true:
                agent.SetDestination(_player.transform.position);
                break;
        }
    }

    void Dead()
    {

    }
}
