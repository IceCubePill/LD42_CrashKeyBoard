using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Eating : StateMachineBehaviour
{
    private float lastTime;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	    lastTime = Time.time;
        ButtonEvrnt.instant.Eating_Button();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
        UIManager.instant.SetAngryBar(-15);
	    ButtonEvrnt.instant.EatingRestTime = Time.time - lastTime;

        AnimateManager.instant.anima.SetFloat("EatingTime", ButtonEvrnt.instant.EatingRestTime);

	    Transform item;

        if (AnimateManager.instant.LeftHand.transform.childCount>0)
	    {
	        item = AnimateManager.instant.LeftHand.transform.GetChild(0);
            if (item.GetComponent<Hanburger>())
	            PoolManager.instant.SetHamber(item.gameObject);
            else if(item.GetComponent<Colo>())
	            PoolManager.instant.SetColo(item.gameObject);

        }
	    
	    if (AnimateManager.instant.RightHand.transform.childCount > 0)
	    {
	        item = AnimateManager.instant.RightHand.transform.GetChild(0);
            if( item.GetComponent<Hanburger>())
	            PoolManager.instant.SetHamber(item.gameObject);
	        else if (item.GetComponent<Colo>())
                PoolManager.instant.SetColo(item.gameObject);

	    }
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	//}
}
