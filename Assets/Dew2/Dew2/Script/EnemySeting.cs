using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject _player;
    public Transform target;

    private Camera _camera;

    private ReactionEnemy _scriptRect;

    List<Transform> _point = new List<Transform>();

    private  int _randomTarget, _randomAct;// рандомные числа _randomTarget-куда идти _randomAct - действие


    private float  _trargetDistance;
    public float agarDistance;

    public float time, timer = 15;//таймер

    public bool fear;//страх


    private void Awake()
    {
        _camera = Camera.main;
        time = timer;
        agent = GetComponent<NavMeshAgent>();   
        _scriptRect = GetComponentInChildren<ReactionEnemy>();
        foreach (Transform Target in target.GetComponentInChildren<Transform>())//добавить в list
        {
            _point.Add(Target);
        }

    }
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        
        Idle();
    }

   //действи при нормально состоянии 
   public void Walking()
    {
        
    }
    void Idle()
    {
        if (_trargetDistance > 3)
        {
            agent.SetDestination(_point[_randomTarget].position);
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
                        time = timer;

                    }
                    break;
            }
        }

    }

    void Agar()
    {
       
            agent.SetDestination(target.transform.position);
             _scriptRect.Achtung(fear);
    }

    public void Dead()
    {

    }
}
