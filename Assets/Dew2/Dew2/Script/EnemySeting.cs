using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeting : MonoBehaviour
{

    private NavMeshAgent _agent;
    NavMeshPath nav_mesh_path;
    public GameObject pointArray;

    public GameObject _player { private get; set; }
    private Animator _animator;
    public GameObject _pie;

    List<Transform> _point = new List<Transform>();

    private int _randomTarget, _randomAct;// рандомные числа _randomTarget-куда идти _randomAct - действие


    private float _trargetDistance;
    public float agarDistance;
    public float time, timer = 15;//таймер

    public bool aggressor;//агрессивный
    public bool _blindness{ private get; set; }//слепота

    public bool Trigger;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _animator = GetComponent<Animator>();
        pointArray = GameObject.FindWithTag("Points");
        time = timer;
        _agent = GetComponent<NavMeshAgent>();
        nav_mesh_path = new NavMeshPath();
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
        
        
        if (!Trigger && !_blindness)
        {
            _blindness = false;
            _trargetDistance = Vector3.Distance(gameObject.transform.position, _point[_randomTarget].transform.position);
            Walking();
        }
        else if(_blindness)
        {
            //Blindne();
        }
        else if (Trigger && !_blindness)
        {
            _trargetDistance = Vector3.Distance(gameObject.transform.position, _player.transform.position);
            Reaction();
        }
    }

    //действи при нормально состоянии 
    private void Walking()
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
    private void Fear()
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

    private void Agar(Transform target)
    {
        _animator.SetBool("Box", true);

        if (_trargetDistance <= _agent.stoppingDistance)
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Run", false);
            _randomAct = Random.Range(0, 1);

            time -= Time.deltaTime * 2;
            if (time <= 1)
            {
                _randomAct = Random.Range(1, 2);
    
                _animator.SetFloat("intHook", _randomAct);
                
                time = Random.Range(4, 6);

            }
        }
        else
        {
            Go_to_near_random_point();
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
            _animator.SetFloat("intHook", 0);
            _agent.speed = 3.4f;
           
      
                    
            }
        transform.LookAt(target.transform.position);

    }
    private void Go_to_near_random_point()
    {// случайная точка на навмеше с проверкой досягаемости
        bool get_correct_point = false; // сгенерировалась ли корректная точка на навмеше
        while (!get_correct_point)
        {
            NavMeshHit navmesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * 2 + _player.transform.position, out navmesh_hit, 2, NavMesh.AllAreas);
            Vector3 random_point = navmesh_hit.position;
            if (random_point.y > -10000 && random_point.y < 10000) // проверка на бесконечное значение, при движении игрока
            {
                _agent.CalculatePath(random_point, nav_mesh_path);
            }
            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete && !NavMesh.Raycast(_player.transform.position, random_point, out navmesh_hit, NavMesh.AllAreas))
            {
                get_correct_point = true; // если путь корректный и между игроком и выбранной точкой нет препятствий
            }

            _agent.SetDestination(random_point);
        }
    }
    
   /*public void Blindne()
    {
        _pie.SetActive(true);
        _agent.Stop();
        time -= Time.deltaTime * 2;
        if (time <= 1)
        {
            
            _pie.SetActive(false);
            _agent.Resume();
            _blindness = false;

        }
    }*/
    public void Dead()
    {
        _agent.Stop();
        _animator.enabled = false;
        Destroy(gameObject, 5);
    }
}
