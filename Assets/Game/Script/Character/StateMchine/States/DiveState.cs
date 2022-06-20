using Character.Control;
using System.Collections;
using UnityEngine;

namespace Character.StateMachine
{
    public class DiveState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Dive();
            controller.Animator.Dive();
            controller.Particle.Move();
            controller.HeadControl.HeadIdleInDive();
        }

        public override void ExitState(CharacterControl controller)
        {
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            Debug.Log("dive " + controller.Animator.EndDive());
            if (controller.Control.head())
            {
                controller.HeadControl.HeadInDive();
                controller.Animator.Head();
            }
            if (controller.Animator.EndDive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
        }
    }
}

