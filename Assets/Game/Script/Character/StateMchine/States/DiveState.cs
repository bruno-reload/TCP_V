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
            controller.SoundControl.Dive();
        }

        public override void ExitState(CharacterControl controller)
        {
            controller.SoundControl.Fall();
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            //if (collision.gameObject.CompareTag("Ball"))
            //{
            //    controller.SoundControl.Blow(SOUND_KEY.body);
            //}
        }

        public override void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            if (controller.Control.head())
            {
                controller.HeadControl.HeadInDive();
                controller.Animator.Head();
                controller.SoundControl.Head();
            }
            if (controller.Animator.EndDive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
        }
    }
}

