using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : StateMachineBehaviour{
    Unidade myUnidade;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (myUnidade == null) {
            myUnidade = animator.GetComponent<Unidade>();
        }
        //setar a velocidade de reprodução de ataque;
        animator.speed = stateInfo.length/myUnidade.AtaqueDelay;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.speed = 1;
        //Aplicar dano
        myUnidade.Target.ApplyDamage(myUnidade.Damage);
    }
}
