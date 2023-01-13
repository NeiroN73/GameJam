using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOptions : MonoBehaviour
{
  public void SacleDead()
    {
        transform.localScale = new Vector3(0.2f, 0.02f, 0.2f);
    }
   public void EventDestroy()
    {
        Destroy(gameObject, 4);
    }
}
