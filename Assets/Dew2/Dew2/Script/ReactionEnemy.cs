using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ReactionEnemy : MonoBehaviour 
{
    public Transform arrayReaction;
    List<GameObject> listReactions = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject Reactions in gameObject.GetComponentInChildren<Transform>())
        {
            listReactions.Add(Reactions);
        }
    }
    
    public void Sight(Camera camera, bool fear)
    {
        transform.LookAt(camera.transform.position);
        switch (fear)
        { 
            case false:

            foreach (GameObject Reactions in listReactions)
            {
                Reactions.SetActive(true);
            }
                break;
            case true:
                 for (int i = 1; i < listReactions.Count; i++ )
                {
                    listReactions[i].SetActive(true);
                }
                break;
        }
    }
}
