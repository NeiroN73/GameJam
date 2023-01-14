using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOptions : MonoBehaviour
{
    private EnemySeting _seting;

    private void Awake()
    {
        _seting = GetComponent<EnemySeting>();
      
   
    }
    public void SacleDead()
    {
        transform.localScale = new Vector3(gameObject.transform.localScale.x, 0.02f, gameObject.transform.localScale.z);
        _seting.Dead();
    }
    public void EfectBlindnes()
    {
        _seting._blindness = true;
        _seting.time = 5;
    }
   public void EventDeadh()
    {

    
        _seting.Dead();
    }
   
}
