using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour
{
    private Animator _animator;
    public Animation _animation;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            print("h");
            
            _animator.Play("Throw", 0, 0);
            //_animation.Play("Goalie Throw");
        }
    }
}
