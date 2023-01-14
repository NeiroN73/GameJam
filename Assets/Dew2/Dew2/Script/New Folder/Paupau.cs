using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paupau : MonoBehaviour
{
    private Animator _anims;
    private AudioSource _source;

    public AudioClip Shoot;
    public AudioClip —harges;
    private void Awake()
    {
        _anims = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _anims.SetBool("Shoot", true);
        }
        else
        {
            _anims.SetBool("Shoot", false);
        }

    }
    public void AudioShoot()
    {
        _source.PlayOneShot(Shoot);
    }
    public void Audio—harges()
    {
        _source.PlayOneShot(—harges);
    }
    
}
