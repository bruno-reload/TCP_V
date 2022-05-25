using System;
using UnityEngine;

namespace Ball
{

    [RequireComponent(typeof(SphereCollider)),
    RequireComponent(typeof(Rigidbody))]
    public class Bounce : MonoBehaviour
    {
        private float size;
        private RaycastHit hit;
        public float speed = 10;
        private Vector3 startPos;
        [SerializeField] private GameObject BallPositionPrediction;
        public const float gravity = 9.81f;

        private void Reset()
        {
            gameObject.tag = "Ball";

            this.BallPositionPrediction = GameObject.CreatePrimitive(PrimitiveType.Cube);
            this.BallPositionPrediction.name = "BallPositionPrediction";
            this.BallPositionPrediction.GetComponent<BoxCollider>().isTrigger = true;
            this.BallPositionPrediction.GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("ForecastPosition adicionado");

        }
        void Start()
        {
            this.size = 2f;
            this.startPos = transform.position;
            if (this.BallPositionPrediction == null)
            {
                Debug.LogError("o game objeto Forecast não existe, reset o componete BallControl.");
            }
            else
            {
                gameObject.AddComponent<Prediction>();
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
        private void FixedUpdate()
        {
            RaycastHit hit;

            Vector3 velocity = GetComponent<Rigidbody>().velocity;

            if (Physics.Raycast(transform.position, velocity.normalized, out hit, size))
            {
                this.hit = hit;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Head"))
            {
                Headed();
                GetComponent<Prediction>().Calculate();
            }
        }
        private void Headed()
        {
            Transform neck = hit.collider.GetComponentInParent<Transform>();
            GetComponent<Transform>().rotation = Quaternion.LookRotation(neck.up, -neck.right);
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
    }
}