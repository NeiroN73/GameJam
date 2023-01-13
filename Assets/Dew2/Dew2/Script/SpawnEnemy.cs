using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int[] numberEnemy;
    public GameObject[] Enemy;

    public static bool Stops;

    public float time, timer = 3;

   
    public void SpawnSkeleton()
    {

       
        time -= Time.deltaTime * 2;
        if (time <= 1)
        {
            if (numberEnemy[0] > 0 && numberEnemy != null)
            {
                Instantiate(Enemy[0], transform.position, Quaternion.identity);
                numberEnemy[0]--;
            }
        }

    }
    public void SpawnPolice()
    {
        
        if (numberEnemy[1] > 0 && numberEnemy != null)
        {
            Instantiate(Enemy[1], transform.position, Quaternion.identity);
            numberEnemy[1]--;
        }
 
    }
}
