using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class MovingState : State
    {
        public override void EnterState(CharacterControl controller)
        {
        }

        public override void ExitState(CharacterControl controller)
        {
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
        }

    }

}
