using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance; // Singleton instance

    public float speed = 10.0f; // The speed of the ball.
    public Rigidbody ball; // The ball's Rigidbody component.
    public Vector3 initialPosition1, initialPosition2; // The initial position of the ball.
    public float force;
    public float spinForce; // the amount of spin to apply to the ball
    public TrailRenderer TrailBall;

    private Rigidbody ballRigidbody;
    public Animator audienceAnimator; // Reference to the audience animator
    public bool scored=false;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this script
            instance = this;
        }
        else
        {
            // If an instance already exists, destroy this script
            Destroy(this);
        }
    }

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // get input for applying spin
        float spinInput = Input.GetAxis("Horizontal");

        // calculate spin direction
        Vector3 spinDirection = transform.up * spinInput;

        // apply spin to the ball
        ball.AddTorque(spinDirection * spinForce * Time.deltaTime);
    }

    // Serve the ball towards the opponent's court.
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Second"))
        {
            scored = true;
            ResetBall(true);
            GameManager.instance.score1 += 1;
            
        }
        if (collision.gameObject.CompareTag("First"))
        {
            scored = true;
            ResetBall(false);
            GameManager.instance.score2 += 1;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (collision.gameObject.transform.position - transform.position).normalized;
            ball.AddForce(-direction * force);
            ball.useGravity = true;
            
        }
    }

    public void ResetBall(bool where)
    {
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
        ball.useGravity = false;

        if (where)
            transform.position = initialPosition1;
        else
            transform.position = initialPosition2;

        TrailBall.Clear();
    }
}
