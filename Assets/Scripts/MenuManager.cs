using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    Animator animator = null;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void MainToDeck(){
        animator.SetTrigger("MainToDeck");
    }

    public void DeckToMain(){
        animator.SetTrigger("DeckToMain");
    }
}
