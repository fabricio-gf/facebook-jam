using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    Animator animator = null;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void TriggerAnimation(string anim){
        animator.SetTrigger(anim);
    }
}
