using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public static GUIManager instance = null;

    public Animator animator = null;
    
    void Awake(){
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        //animator = GetComponent<Animator>();
    }
    
    public void HidePanel(){
        animator.SetTrigger("HidePanel");
    }

    public void ShowPanel(){
        animator.SetTrigger("ShowPanel");
    }
}
