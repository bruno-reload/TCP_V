using Character.Control;
using System;
using UnityEngine;


namespace Character
{

    public class CharacterBehaviour : MonoBehaviour
    {

        [SerializeField] private CharacterProperties characterProperties;
        [SerializeField] private Quaternion forwardRotation;
        private CharacterControl characterControl;
        private Rigidbody characterRigidbody;
        public Transform ballTransform;

        public CharacterProperties CharacterProperties { get => characterProperties; }
        public CharacterControl CharacterController { get => characterControl; set => characterControl = value; }
        public bool isMoving => characterControl.Control.direction() != Vector3.zero;
        private Quaternion targetRotation(float x, float z)
        {
            float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            Quaternion targetAngle = Quaternion.AngleAxis(angle, Vector3.up);
            return Quaternion.Slerp(transform.rotation, targetAngle, characterProperties.RotationSpeed * Time.fixedDeltaTime);
        }

        private void Awake()
        {
            characterRigidbody = GetComponent<Rigidbody>();
            characterControl = GetComponent<CharacterControl>();
        }

        private void WalkBehaviour(Vector3 direction, float speed)
        {
            Vector3 xzDirectionClamp = Vector3.ClampMagnitude(direction, 1);
            characterRigidbody.velocity = new Vector3(xzDirectionClamp.x * speed, characterRigidbody.velocity.y, xzDirectionClamp.z * speed);
        }

        private void JumpBehaviour(float impulse)
        {
            characterRigidbody.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        }

        private void Rotate()
        {
            if (characterControl.Control.direction().magnitude > 0.1f)
            {
                transform.rotation = targetRotation(
                    characterControl.Control.direction().x, characterControl.Control.direction().z);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, forwardRotation,
                    characterProperties.RotationSpeed * Time.fixedDeltaTime);

            }
        }

        public void Moving()
        {
            WalkBehaviour(characterControl.Control.direction(), characterProperties.Speed);
            //if (characterControl.Control.direction() != Vector3.zero) 
            Rotate();
        }

        public void Jumping()
        {
            JumpBehaviour(characterProperties.JumpImpulse);
        }

        //Movimento de mergulho
        public void Dive()
        {
            Vector3 direction = (transform.forward + Vector3.up * ((characterProperties.DiveImpoulse/2)/ characterProperties.DiveImpoulse));
            characterRigidbody.AddForce(direction * characterProperties.DiveImpoulse, ForceMode.Impulse);
        }
    }
}

