using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int[] numberEnemy;
    public GameObject[] Enemy;

    public bool Triger = false;

    private void FixedUpdate()
    {
        if(Triger)
        {
            StartCoroutine(SpawnSkeleton());

        }
        
    }
    public IEnumerator SpawnSkeleton()
    {
        Triger = false;
        if (numberEnemy[0] > 0 && numberEnemy != null)
        {
            Instantiate(Enemy[0], transform.position, Quaternion.identity);
            numberEnemy[0]--;
        }
        yield return new WaitForSeconds(3f);
        Triger = true;
    }
    public IEnumerator SpawnPolice()
    {
        if (numberEnemy[1] > 0 && numberEnemy != null)
        {
            Instantiate(Enemy[1], transform.position, Quaternion.identity);
            numberEnemy[1]--;
        }
        yield return new WaitForSeconds(1000f);
    }
}
