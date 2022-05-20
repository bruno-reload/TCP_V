using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.StateMachine
{
    public class MovingState : State
    {
        public override void EnterState(CharacterBehaviour behaviours)
        {
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
        }

        public override void UpdateState(CharacterBehaviour behaviours, FiniteStateMachine stateMachine)
        {

            if (behaviours.PlayerInput.direction == Vector3.zero)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
            if (behaviours.PlayerInput.jump)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
            }
        }

    }

}
