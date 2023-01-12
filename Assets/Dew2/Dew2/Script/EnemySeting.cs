using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{

    private NavMeshAgent _agent;
    public GameObject pointArray;

    public GameObject _player { private get; set; }
    private Animator _animator;
    private GameObject _pie;

    List<Transform> _point = new List<Transform>();

    private  int _randomTarget, _randomAct;// рандомные числа _randomTarget-куда идти _randomAct - действие


    private float  _trargetDistance;
    public float agarDistance;
    public float time, timer = 15;//таймер

    public bool aggressor;//агрессивный
    public bool blindness;//слепота

    public bool Trigger;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponent<Animator>();
        pointArray = GameObject.FindWithTag("Points");
        time = timer;
        _agent = GetComponent<NavMeshAgent>();   
        foreach (Transform Points in pointArray.GetComponentInChildren<Transform>())//добавить в list
        {
            _point.Add(Points);
        }
    }
    public void Reaction()
    {
       switch (aggressor)
        {
            case true:
                Trigger = true;
                Agar(_player.transform);
                break;
            case false:
                Fear();
                break;
            default:
                break;
        }
        
    }

    private void FixedUpdate()
    {
        
        
        if (!Trigger)
        {
            _trargetDistance = Vector3.Distance(gameObject.transform.position, _point[_randomTarget].transform.position);
            Walking();
        }
        else
        {
            _trargetDistance = Vector3.Distance(gameObject.transform.position, _player.transform.position);
            Reaction();
        }
    }

   //действи при нормально состоянии 
   public void Walking()
    {
        if (_trargetDistance > _agent.stoppingDistance)
        {
            _agent.SetDestination(_point[_randomTarget].position);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
        }
        else
        {
            _randomAct = Random.Range(0, 1);
            switch (_randomAct)
            {
                case 1:
                    _randomTarget = Random.Range(0, _point.Count);
                    break;
                default://ожидание при 0
                    time -= Time.deltaTime * 2;
                    if (time <= 1)
                    {
                        _randomTarget = Random.Range(0, _point.Count);
                        _animator.SetBool("Idle", false);
                        _animator.SetBool("Run", true);
                        time = timer;

                    }
                    else
                    {
                        _animator.SetBool("Idle",true);
                        _animator.SetBool("Run", false);
                    }
                    break;
            }
        }
    }
    void Fear()
    {
        
        if (_trargetDistance > _agent.stoppingDistance)
        {
            _agent.SetDestination(_point[_randomTarget].position);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
            
        }
        else 
        {
            _randomTarget = Random.Range(0, _point.Count);
        }
    }

    public void Agar(Transform target)
    {
        _animator.SetBool("Box", true);

        if (_trargetDistance <= _agent.stoppingDistance)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Run", false);

        }
        else
        {
            
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
            _agent.SetDestination(target.position);
            _agent.speed = 3.4f;
        }
        transform.LookAt(target.transform.position);
    }

    public void Dead()
    {

    }
}
