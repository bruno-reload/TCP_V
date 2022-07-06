
using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class IdleState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Animator.Idle();
            controller.Particle.Idle();
        }

        public override void ExitState(CharacterControl controller)
        {
        }
        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            if (controller.Control.head())
            {
                controller.HeadControl.Head();
                controller.Animator.Head();
                controller.SoundControl.Head();
            }
            if (controller.Animator.Floor && controller.Animator.EndDive())
            {
                if (controller.Control.jump())
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
                    controller.SoundControl.Jump();
                }
                if (controller.Control.dive())
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
                }
            }
            if (controller.Behaviour.isMoving && controller.Animator.EndDive())
            {
                controller.SoundControl.Stop();
                stateMachine.TransitionToState(stateMachine.StateInstances.movingState);
            }

        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            //if (collision.gameObject.CompareTag("Ball")) {
            //    controller.SoundControl.Blow(SOUND_KEY.body);
            //}
        }
    }
}

