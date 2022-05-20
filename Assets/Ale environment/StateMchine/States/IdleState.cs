
using Player;
using UnityEngine;

namespace Character.StateMachine
{
    public class IdleState : State
    {
        public override void EnterState(CharacterBehaviour behaviour)
        {
        }

        public override void ExitState(CharacterBehaviour behaviour)
        {
        }
        public override void UpdateState(CharacterBehaviour behaviour, FiniteStateMachine stateMachine)
        {
            if (behaviour.PlayerInput.direction != Vector3.zero)
            {
                stateMachine.TransitionToState( stateMachine.StateInstances.movingState);
            }

            if(behaviour.PlayerInput.jump)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
            }
        }

        public override void FixedUpdateState(CharacterBehaviour behaviour)
        {
            behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterBehaviour behaviour, FiniteStateMachine stateMachine, Collision collision)
        {
        }


    }
}

