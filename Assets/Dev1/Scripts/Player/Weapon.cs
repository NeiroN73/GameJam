using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public PlayerAnimator playerAnimator; //later change

    public abstract void PlayAnimation();
}
