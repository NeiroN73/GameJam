using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public List<GameObject> GameObjects = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Enemy") || other.CompareTag("Item"))
        {
            case true:
            GameObjects.Add(other.gameObject);
                break;
            case false:
                break;
            default:
                GameObjects.Clear();
                break;
        }

            
            
        
    }

    void OnTriggerExit(Collider other)
    {
        switch (other.CompareTag("Enemy") || other.CompareTag("Item"))
        {
            case true:
                GameObjects.Remove(other.gameObject);
                break;
            default:
                GameObjects.Clear();
                break;

        }
        
    }
}
