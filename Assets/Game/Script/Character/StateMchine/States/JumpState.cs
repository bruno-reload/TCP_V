using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterControl controller)
        {
            controller.Animator.Jumping();
            controller.Behaviour.Jumping();
            controller.Particle.Jumping();
            controller.SoundControl.Jump();
        }
        public override void ExitState(CharacterControl controller)
        {
            controller.Particle.Fall();
        }
        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
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
            controller.Animator.Jumping();
            if (controller.Control.head())
            {
                controller.HeadControl.Head();
                controller.Animator.Head();
                controller.SoundControl.Head();
            }
            if (controller.Animator.Floor)
            {
                if (controller.Control.dive())
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
                }
                if (controller.Behaviour.isMoving)
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.movingState);
                }
                else
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
                }
            }
        }
    }
}
