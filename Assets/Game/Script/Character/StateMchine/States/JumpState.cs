using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Jumping();
            controller.Animator.Jumping();
            controller.Particle.Jumping();
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
            if (controller.Animator.Floor && controller.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
        }
    }

}
