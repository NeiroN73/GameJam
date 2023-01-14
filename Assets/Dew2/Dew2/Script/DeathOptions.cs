using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOptions : MonoBehaviour
{
    private EnemySeting _seting;
    private Bones _bones;
    private void Awake()
    {
        _seting = GetComponent<EnemySeting>();
        _bones = GetComponentInChildren<Bones>();
   
    }
    public void SacleDead()
    {
        transform.localScale = new Vector3(0.2f, 0.02f, 0.2f);
        _seting.Dead();
    }
    public void EfectBlindnes()
    {
        _seting._blindness = true;
        _seting.time = 5;
    }
   public void EventDeadh()
    {

        _bones.MakePhisical();
        _seting.Dead();
    }
   
}
