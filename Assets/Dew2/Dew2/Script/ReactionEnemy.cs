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
        
    }
    private void Update()
    {
        _distance = Vector3.Distance(gameObject.transform.position, _player.transform.position);
          if (_distance <= 4)
        {
           Sight(true);
        }
          else
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
            default:
            barKey.SetActive(false);
                break;
        }
        transform.LookAt(_camera.transform.position);
    }
}
