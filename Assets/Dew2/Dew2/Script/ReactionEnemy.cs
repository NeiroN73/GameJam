using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ReactionEnemy : MonoBehaviour 
{
    public GameObject barKey;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        
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
