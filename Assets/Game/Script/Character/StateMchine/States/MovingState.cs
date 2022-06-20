using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class MovingState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Moving();
            controller.Animator.Move();
            controller.Particle.Move();
        }

        public override void ExitState(CharacterControl controller)
        {
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {

        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            Debug.Log("move " + controller.Animator.EndDive());
            if (controller.Control.head())
            {
                controller.HeadControl.Head();
                controller.Animator.Head();
            }
            if (controller.Animator.Floor && controller.Animator.EndDive())
            {
                if ( controller.Control.jump())
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
                }
                if (controller.Control.dive())
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
                }
            }
            if (!controller.Behaviour.isMoving && controller.Animator.EndDive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }

        }

    }

}
