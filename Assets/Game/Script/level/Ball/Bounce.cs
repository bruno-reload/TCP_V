using System;
using UnityEngine;

namespace Ball
{

    [RequireComponent(typeof(SphereCollider)),
    RequireComponent(typeof(Rigidbody))]
    public class Bounce : MonoBehaviour
    {
        public float speed = 13;
        public GameObject BallPositionPrediction;
        public const float gravity = 9.81f;

        private void Reset()
        {
            gameObject.tag = "Ball";

            this.BallPositionPrediction = GameObject.CreatePrimitive(PrimitiveType.Cube);
            this.BallPositionPrediction.tag = "Prediction";
            this.BallPositionPrediction.name = "BallPositionPrediction";
            this.BallPositionPrediction.GetComponent<BoxCollider>().isTrigger = true;
            this.BallPositionPrediction.GetComponent<MeshRenderer>().enabled = false;

            this.BallPositionPrediction.AddComponent<Rigidbody>();
            this.BallPositionPrediction.GetComponent<Rigidbody>().useGravity = false;
            this.BallPositionPrediction.GetComponent<Rigidbody>().isKinematic = true;
        }
        void Start()
        {
            if (this.BallPositionPrediction == null)
            {
                Debug.LogError("o game objeto Forecast n�o existe, reset o componete BallControl.");
            }
            else
            {
                gameObject.AddComponent<Prediction>();
                gameObject.GetComponent<Prediction>().SetPositionFeedback(BallPositionPrediction);
                if (this.BallPositionPrediction.GetComponent<BoxCollider>() == null)
                {
                    Debug.LogWarning("o game objeto ForeCast deve conter um BoxCollider");
                }
                else
                {
                    if (this.BallPositionPrediction.GetComponent<BoxCollider>() != null)
                    {
                        this.BallPositionPrediction.GetComponent<BoxCollider>().isTrigger = true;
                        this.BallPositionPrediction.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Head"))
            {
                Headed(collision.contacts[0]);
                GetComponent<Prediction>().Calculate();
            }
        }
        private void Headed(ContactPoint head)
        {
            GetComponent<Transform>().rotation = Quaternion.LookRotation(head.normal, Vector3.up);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

        public void SetForecast(Vector3 value)
        {
            this.BallPositionPrediction.transform.position = value;
        }
        public Vector3 GetForecast()
        {
            return this.BallPositionPrediction.transform.position; ;
        }
    }
    public class Prediction : MonoBehaviour
    {
        public GameObject feedback;

        private void Reset()
        {
            gameObject.AddComponent<Bounce>();
        }
        public void Calculate()
        {
            float speedX = GetComponent<Rigidbody>().velocity.x;
            float speedY = GetComponent<Rigidbody>().velocity.y;
            float speedZ = GetComponent<Rigidbody>().velocity.z;

            float tUp = speedY / Bounce.gravity;

            float h = transform.position.y + speedY * tUp;

            float tDown = Mathf.Sqrt(h / Bounce.gravity);

            float t = tUp + tDown;

            float x = transform.position.x + speedX * t;
            float y = 0;
            float z = transform.position.z + speedZ * t;

            GetComponent<Bounce>().SetForecast(new Vector3(x, y, z));
        }

        public void SetPositionFeedback(GameObject target)
        {
            this.feedback = GameObject.CreatePrimitive(PrimitiveType.Quad);
            this.feedback.GetComponent<MeshCollider>().enabled = false;
            this.feedback.transform.SetParent(target.transform);
            this.feedback.name = "feedback";
            this.feedback.transform.localScale = new Vector3(5.5f, 5.5f, 0);
            this.feedback.transform.rotation = Quaternion.Euler(90, 0, 0);
            this.feedback.transform.localPosition = new Vector3(0, 0.8f, 0);
            Material mat = target.GetComponent<MeshRenderer>().material;
            this.feedback.GetComponent<MeshRenderer>().material = mat;
        }
    }
}