using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.StateMachine;
using Player;

namespace Character
{

    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private CharacterProperties characterProperties;
        [SerializeField] private float speedRotation;
        private PlayerInput playerInput;

        public PlayerInput PlayerInput { get => playerInput; set => playerInput = value; }

        private Rigidbody characterRigidbody;
        public Transform ballTransform;
        public Quaternion startRotation;
        public Quaternion targetRotation(float x, float z)
        {       
            float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            Quaternion targetAngle = Quaternion.AngleAxis(angle, Vector3.up);
            return Quaternion.Slerp(transform.rotation, targetAngle, speedRotation * Time.fixedDeltaTime);

        }

        private void Awake()
        {
            characterRigidbody = GetComponent<Rigidbody>();
            playerInput = GetComponent<PlayerInput>();
        }

        private void WalkBehaviour(float x, float z, float speed)
        {
            Vector3 xzDirection = Vector3.ClampMagnitude(new Vector3(x,0, z), 1);
            characterRigidbody.velocity = new Vector3(xzDirection.x * speed, characterRigidbody.velocity.y, xzDirection.z * speed);
        }

        private void JumpBehaviour(float impulse)
        {
            characterRigidbody.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        }
        private void Rotate()
        {
            Debug.Log(playerInput.rawDirection);
            if (playerInput.rawDirection.magnitude > 0.1f)
            {
                transform.rotation = targetRotation(playerInput.direction.x, playerInput.direction.z);
            }
            else{

                //TODO: ajustar
                //Quaternion targetRotation = Quaternion.LookRotation(ballTransform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, speedRotation*Time.fixedDeltaTime);

            }
        }

        public void Moving()
        {
            WalkBehaviour(playerInput.xAxis, playerInput.yAxis, characterProperties.Speed);
            if(playerInput.direction != Vector3.zero)
                Rotate();
        }

        public void Jump()
        {
            JumpBehaviour(characterProperties.JumpImpulse);
        }

        //Movimento de mergulho
        public void Dive()
        {

        }

        //Ação de cabecear
        public void Head()
        {

        }
    }

}
