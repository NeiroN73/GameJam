using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject _player;
    public Transform pointArray;

    private Camera _camera;

    private ReactionEnemy _scriptRect;

    List<Transform> _point = new List<Transform>();

    private  int _randomTarget, _randomAct;// ��������� ����� _randomTarget-���� ���� _randomAct - ��������


    private float  _trargetDistance;
    public float agarDistance;
    public float time, timer = 15;//������

    public bool aggressor;//�����������
    public bool blindness;//�������

    private void Awake()
    {
        _camera = Camera.main;
        time = timer;
        agent = GetComponent<NavMeshAgent>();   
        _scriptRect = GetComponentInChildren<ReactionEnemy>();
        foreach (Transform Points in pointArray.GetComponentInChildren<Transform>())//�������� � list
        {
            _point.Add(Points);
        }
        _player = GameObject.FindWithTag("Player");
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

        Walking();
    }

   //������� ��� ��������� ��������� 
   public void Walking()
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
       

    }

    void Agar(GameObject target)
    {
       
            agent.SetDestination(target.transform.position);
    }

    public void Dead()
    {

    }
}
