using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public abstract class State  : MonoBehaviour
    {
        public abstract void EnterState(CharacterControl controller);
        public abstract void UpdateState(CharacterControl controller, FiniteStateMachine stateMachine);
        public abstract void FixedUpdateState(CharacterControl controller, FiniteStateMachine stateMachine);
        public abstract void OnCollisionEnterState(CharacterControl controller, Collision collision, FiniteStateMachine stateMachine);
        public abstract void ExitState(CharacterControl controller);

    }
}

