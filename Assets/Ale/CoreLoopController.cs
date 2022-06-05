using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CoreLoopController : MonoBehaviour
    {
        [SerializeField] private CoreLoopHandler[] coreLoopHandlers;
        [SerializeField] private CoreLoopHandler currentState;

        public CoreLoopState nextCoreLoopState
        {
            get
            {
                int currentIndex = Array.IndexOf(coreLoopHandlers, currentState);
                if (currentIndex < coreLoopHandlers.Length -1)
                {
                    return coreLoopHandlers[currentIndex + 1].State;
                }
                return coreLoopHandlers[0].State;

            }
        }

        public void TransitionToState(CoreLoopState state)
        {
            currentState.StateEnd();
            currentState = GetHandler(state);
            currentState.StateStart();
        }

        private CoreLoopHandler GetHandler(CoreLoopState state)
        {
            foreach (CoreLoopHandler handler in coreLoopHandlers)
            {
                if (handler.State == state)
                    return handler;
            }
            return null;

        }

        public void Restart()
        {
            foreach(CoreLoopHandler handler in coreLoopHandlers)
            {
                handler.Hide();
            }
            TransitionToState(CoreLoopState.saque);

        }

        public void NextStep()
        {
            TransitionToState(nextCoreLoopState);
        }

        #region para fins de desenvolvimento
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5)) TransitionToState(CoreLoopState.saque);
            if (Input.GetKeyDown(KeyCode.F6)) TransitionToState(CoreLoopState.desenrolar);
            if (Input.GetKeyDown(KeyCode.F7)) TransitionToState(CoreLoopState.ponto);
            if (Input.GetKeyDown(KeyCode.N)) TransitionToState(nextCoreLoopState);
        }
        #endregion
    }

}
