using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum Players
    {
        Player1,
        Player2
    }

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Players players;
        private int playerIndex => (int)players + 1;
        public float xAxis => Input.GetAxis("Horizontal" + playerIndex.ToString());
        public float yAxis => Input.GetAxis("Vertical" + playerIndex.ToString());
        public float xRawAxis => Input.GetAxisRaw("Horizontal" + playerIndex.ToString());
        public float yRawAxis => Input.GetAxis("Vertical" + playerIndex.ToString());
        public Vector3 direction => new Vector3(xAxis, 0, yAxis);
        public Vector3 rawDirection => new Vector3(xRawAxis, 0, yRawAxis);
        public bool jump => Input.GetButtonDown("Jump" + playerIndex.ToString());
        public bool head => Input.GetButtonDown("Jump" + playerIndex.ToString());
        public bool dive => Input.GetButtonDown("Jump" + playerIndex.ToString());
        public bool axisDown =>  
            Input.GetButtonDown("Horizontal" + playerIndex.ToString()) ||
            Input.GetButtonDown("Horizontal" + playerIndex.ToString())
                ? true : false;

        private void Update()
        {
            //Debug.Log(direction);
        }
    }
}

