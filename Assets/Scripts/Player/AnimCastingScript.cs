using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCastingScript : StateMachineBehaviour
{
    private static readonly int IsFiringHash = Animator.StringToHash("IsFiring");
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Casting Complete");
        animator.SetBool(IsFiringHash, false);
    }
}
