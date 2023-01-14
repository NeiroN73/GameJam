using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateAmmunition : MonoBehaviour
{
    [Tooltip(" health")]
    public int Health = 100;

    public int damage;

    private EnemySeting _enemy;
    private DeathOptions _death;
    private AudioSource _source;

    public AudioClip Hits;
    public AudioClip DamagClip;
    public AudioClip DeadsClip;

    public void Awake()
    {
        _source = GetComponent<AudioSource>();
        _enemy = GetComponent<EnemySeting>();
        _death = GetComponent<DeathOptions>();
    }
    public void Hit(int hit, GameObject target)
    {

        Health -= hit;
        _enemy.Reaction();

        _enemy._player = target;
        _source.PlayOneShot(DamagClip);
        if (Health <= 0)
        {
            _death.EventDeadh();
            _source.PlayOneShot(DeadsClip);
        }

    }
    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 2);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out StateAmmunition enemy))
            {
                _source.PlayOneShot(Hits);
                // enemy.Hit(damage, gameObject);
            }
        }
    }
}
