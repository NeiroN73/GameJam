using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{

    private NavMeshAgent _agent;
    public Transform pointArray;

    private GameObject _player;
    private Animator _anim;

    List<Transform> _point = new List<Transform>();

    private  int _randomTarget, _randomAct;// ��������� ����� _randomTarget-���� ���� _randomAct - ��������


    private float  _trargetDistance;
    public float agarDistance;
    public float time, timer = 15;//������

    public bool aggressor;//�����������
    public bool blindness;//�������

    public bool Trigger;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _anim = GetComponent<Animator>();
        time = timer;
        _agent = GetComponent<NavMeshAgent>();   
        foreach (Transform Points in pointArray.GetComponentInChildren<Transform>())//�������� � list
        {
            _point.Add(Points);
        }
    }
    public void Reaction(GameObject target)
    {
       switch (aggressor)
        {
            case true:
                Agar(target);
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
        _trargetDistance = Vector3.Distance(gameObject.transform.position, _point[_randomTarget].transform.position);
        if (Trigger)
        {
            Walking();
        }
        else
        {
            Agar(null);
        }
    }

   //������� ��� ��������� ��������� 
   public void Walking()
    {
        if (_trargetDistance > 3)
        {
            _agent.SetDestination(_point[_randomTarget].position);
        }
        else
        {
            _randomAct = Random.Range(0, 1);
            switch (_randomAct)
            {
                case 1:
                    _randomTarget = Random.Range(0, _point.Count);
                    break;
                default://�������� ��� 0
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
    void Fear()
    {
        _randomTarget = Random.Range(0, _point.Count);

    }

    void Agar(GameObject target)
    {
        Trigger = true;
        if(target= null)
        {
            target = _player;
        }
        _agent.SetDestination(target.transform.position);
        _agent.speed += 2;
    }

    public void Dead()
    {

    }
}
