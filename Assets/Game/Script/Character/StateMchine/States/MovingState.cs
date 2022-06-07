using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class MovingState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Animator.Floor(true);
            controller.Animator.Move();
        }

        public override void ExitState(CharacterControl controller)
        {
            controller.Animator.Floor(false);
        }

        public override void FixedUpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, FiniteStateMachine stateMachine)
        {
            
        }

        public override void UpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
            //processando novos estados 
            if (controller.Control.jump())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
            }
            if (!controller.Behaviour.isMoving)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
            if (controller.Control.dive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
            }
            controller.Animator.Move();
            Debug.Log("move");
        }

    }

}
