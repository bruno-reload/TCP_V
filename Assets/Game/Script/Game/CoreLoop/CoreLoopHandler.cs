using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public enum CoreLoopState
    {
        saque,
        desenrolar,
        ponto
    }

    public class CoreLoopHandler : ViewHandler
    {
        [SerializeField] private CoreLoopState state;
        public CoreLoopState State { get => state;}
        
        public UnityEvent onStateStart;
        public UnityEvent onStateEnd;

        public  void StateStart()
        {
            onStateStart?.Invoke();
            Show();
        }

        public void StateEnd()
        {
            onStateEnd?.Invoke();
            Hide();
        }

    }
}

