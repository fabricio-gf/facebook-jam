using UnityEngine;

public class Pause : MonoBehaviour
{
    Animator animator = null;
    public bool isPaused = false;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    void TogglePause(){
        isPaused = !isPaused;
        if(isPaused){
            Time.timeScale = 0;
            animator.SetTrigger("PauseOn");
        }
        else{
            Time.timeScale = 1;
            animator.SetTrigger("PauseOff");
        }
    }
}
