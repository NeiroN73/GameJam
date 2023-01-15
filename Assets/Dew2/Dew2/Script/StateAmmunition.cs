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

    public GameObject Players;
    public Player _player;

    public void Awake()
    {
        Players = GameObject.FindWithTag("Player");
        _player = Players.GetComponent<Player>();
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
        _source.PlayOneShot(Hits);
        _player.ApplyDamage(damage);
    }
}
