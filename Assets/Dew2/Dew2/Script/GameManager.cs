using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Scelets;
    public SpawnEnemy [] spawn;
    private void FixedUpdate()
    {
        if(Scelets = null)
        {
            foreach (SpawnEnemy Spawns in spawn)
            {
                Spawns.SpawnSkeleton();
            }
        }
    }
}
