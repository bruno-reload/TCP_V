using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(SphereCollider)), RequireComponent(typeof(Rigidbody))]
public class BallControl : MonoBehaviour
{
    private float size;
    private RaycastHit hit;
    public float speed = 10;
    private Vector3 startPos;
    [SerializeField] private GameObject ForeCast;
    private const float gravity = 9.81f;

    private void Reset()
    {
        this.ForeCast = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ForeCast.name = "ForeCast";

        MeshRenderer mr = ForeCast.GetComponent<MeshRenderer>();
        BoxCollider bc = ForeCast.AddComponent<BoxCollider>();

        bc.isTrigger = true;
        mr.enabled = false;

        Debug.Log("ForeCast adicionado");

    }
    void Start()
    {
        this.size = 2f;
        this.startPos = transform.position;
        if (ForeCast == null)
        {
            Debug.LogError("o game objeto Forecast não existe, reset o componete BallControl.");
        }
        else
        {
            if (this.ForeCast.GetComponent<BoxCollider>() == null)
            {
                Debug.LogWarning("o game objeto ForeCast deve conter um BoxCollider");
            }
            else
            {
                if (this.ForeCast.GetComponent<BoxCollider>() != null)
                {
                    this.ForeCast.GetComponent<BoxCollider>().isTrigger = true;
                    this.ForeCast.GetComponent<MeshRenderer>().enabled = false;
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
            Calculate();
            GetComponent<Rigidbody>().detectCollisions = false;
        }
    }
    private void Headed()
    {
        Transform neck = hit.collider.GetComponentInParent<Transform>();
        GetComponent<Transform>().rotation = Quaternion.LookRotation(neck.up, -neck.right);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    private void restart()
    {
        transform.position = this.startPos;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        GetComponent<Rigidbody>().detectCollisions = true;
    }

    private void Calculate()
    {
        float speedX = GetComponent<Rigidbody>().velocity.x;
        float speedY = GetComponent<Rigidbody>().velocity.y;
        float speedZ = GetComponent<Rigidbody>().velocity.z;

        float tUp = speedY / gravity;

        float h = transform.position.y + speedY * tUp;

        float tDown = Mathf.Sqrt(h / gravity);

        float t = tUp + tDown;

        float x = transform.position.x + speedX * t;
        float y = 0;
        float z = transform.position.z + speedZ * t;


        ForeCast.transform.position = new Vector3(x, y, z);
    }
}
