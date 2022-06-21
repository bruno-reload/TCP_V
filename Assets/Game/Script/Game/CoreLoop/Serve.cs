using Ball;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class Serve : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private CoreLoopController coreLoopController;
        
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }


        private void OnEnable()
        {
            ballController.HeadOn += OnBallServed;
        }

        private void OnDisable()
        {
            ballController.HeadOn -= OnBallServed;

        }

        private void Update()
        {
            //if(Input.anyKeyDown)
            //{
            //    //ballController.Serve();
            //}
        }



        private void OnBallServed()
        {
            coreLoopController.TransitionToState(CoreLoopState.ROLLING_BALL);
          
        }

    }
}
