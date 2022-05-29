
using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class IdleState : State
    {
        public override void EnterState(CharacterControl controller )
        {
        }

        public override void ExitState(CharacterControl controller)
        {
        }
        public override void UpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
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
        }

        public override void FixedUpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
            controller.Behaviour.Moving();


        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, FiniteStateMachine stateMachine)
        {
        }


    }
}

