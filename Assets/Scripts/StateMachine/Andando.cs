using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andando : StateMachineBehaviour
{
    Movement MovementScript;
    Unidade myUnidade;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        if (MovementScript == null) {
            MovementScript = animator.GetComponent<Movement>();
        }
        if (myUnidade == null) {
            myUnidade = animator.GetComponent<Unidade>();
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        
        if (myUnidade.Target != null) {
            //MovementScript;
            MovementScript.MoveTowards(myUnidade.Target.transform);
            animator.SetFloat("TargetDistance", Vector3.Distance(myUnidade.Target.transform.position,animator.transform.position));
        } else {
            //achar outro target
            FindNewTarget(animator.transform);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        
    }

    public void FindNewTarget(Transform myTransform) {
        Unidade[] unidades = FindObjectsOfType<Unidade>();
        Vector3 myPosition = myTransform.position;
        foreach (Unidade u in unidades) {
            if (!u.CompareTag(myTransform.tag)) {
                if (myUnidade.Target == null) {
                    myUnidade.Target = u;
                } else {
                    if (Vector2.Distance(u.transform.position, myPosition) < Vector2.Distance(myPosition, myUnidade.Target.transform.position)) {
                        myUnidade.Target = u;
                    }
                }
            }
        }
    }
    
}
