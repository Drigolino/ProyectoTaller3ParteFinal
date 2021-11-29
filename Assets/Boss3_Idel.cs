using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_Idel : StateMachineBehaviour
{
    [SerializeField] Boss3 boss3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3 = GameObject.FindGameObjectWithTag("Boss3").GetComponent<Boss3>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss3.IdelState();
    }

    
}
