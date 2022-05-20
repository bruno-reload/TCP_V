using UnityEngine;

namespace Character.StateMachine
{
    public abstract class State  : MonoBehaviour
    {
        public abstract void EnterState(CharacterBehaviour behaviour);
        public abstract void UpdateState(CharacterBehaviour behaviours, FiniteStateMachine stateMachine);
        public abstract void FixedUpdateState(CharacterBehaviour behaviours);
        public abstract void OnCollisionEnterState(CharacterBehaviour behaviours, FiniteStateMachine stateMachine, Collision collision);
        public abstract void ExitState(CharacterBehaviour behaviours);

    }
}

