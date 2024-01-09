using UnityEngine;
 
public class Jump : MonoBehaviour
{
   private Rigidbody body;
    private int groundContactCount = 0;
    private float time = 0;
    private float launchTime = 0;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
    if (Input.GetButtonDown("space") && IsGrounded())
        {
            body.velocity = new Vector3(body.velocity.x, 5f, body.velocity.z);
 
        }
    }
    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);

    }
 }

