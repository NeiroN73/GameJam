using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ReactionEnemy : MonoBehaviour 
{
    public GameObject barKey;//подсказка
    private Camera _camera;
    private GameObject _player;

    private float _distance;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _camera = Camera.main;
        Sight(false);


    }
    
    private void Update()
    {
        transform.LookAt(_camera.transform.position);


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "before")
        {
            Sight(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "before")
        {
            Sight(false);
        }
    }
    
    public void Achtung( bool fear)
    {
        switch (fear)
        {
            case true:
                
                break;
            case false:

                break;
        }
        Sight(fear);
    }
    //рядом ли Player
    public void Sight(bool beside)
    {
        switch (beside)
        {
            case true:
            barKey.SetActive(true);
                break;
            case false:
            barKey.SetActive(false);
                break; 
        }
        
    }
}
