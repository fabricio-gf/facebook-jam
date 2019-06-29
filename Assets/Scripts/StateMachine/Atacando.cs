using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacando : StateMachineBehaviour{
    Unidade myUnidade;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (myUnidade == null) {
            myUnidade = animator.GetComponent<Unidade>();
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (myUnidade.Target != null) {
            animator.SetBool("Atacando", true);
        } else {
            animator.SetFloat("TargetDistance", float.MaxValue);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }
}
