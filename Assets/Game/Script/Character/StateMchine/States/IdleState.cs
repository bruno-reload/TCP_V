
using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class IdleState : State
    {
        public override void EnterState(CharacterControl controller )
        {
            controller.Animator.Floor(true);
            controller.Animator.Idle();
        }

        public override void ExitState(CharacterControl controller)
        {
            controller.Animator.Floor(false);
        }
        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {            
            //processando novos estados
            if (controller.Behaviour.isMoving)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.movingState);
            }
            if (controller.Control.jump())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
            }
            if (controller.Control.dive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
            }
            Debug.Log("idle");
            controller.Animator.Idle();
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }
    }
}

