using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterBehaviour behaviours)
        {
            behaviours.Jump();
        }
        public override void ExitState(CharacterBehaviour behaviours)
        {
        }
        public override void FixedUpdateState(CharacterBehaviour behaviours)
        {
            behaviours.Moving();
        }

        public override void OnCollisionEnterState(CharacterBehaviour behaviours, FiniteStateMachine stateMachine, Collision collision)
        {
            if(collision.collider.CompareTag("Field")) {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
        }

        public override void UpdateState(CharacterBehaviour behaviours, FiniteStateMachine stateMachine)
        {
        }
    }

}
