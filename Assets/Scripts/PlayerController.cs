using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3f;
    float currentSpeed;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    bool isGrounded = true;
    Animator anim;
    Rigidbody rb;
    Vector3 direction;
    private int health;
    float stamina = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        anim = GetComponent<Animator>(); 
		currentSpeed = movementSpeed;  		
        health = 100;	
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
              
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        anim.SetFloat("Speed",Vector3.ClampMagnitude(direction * currentSpeed, 1).magnitude);
    
        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(new Vector3 (0, jumpForce, 0), ForceMode.Impulse);
            anim.SetBool("Jump", true);
        }

        if(direction.x !=0 || direction.z !=0)
        {
            // anim.SetBool("Walk", true);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            // anim.SetBool("Walk", false);
        }   
	    if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;
            anim.SetBool("running", true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
            anim.SetBool("running", false);
        }
        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     if (stamina > 0)
        //     {
        //         stamina -= Time.deltaTime;
        //         currentSpeed = shiftSpeed;
        //     }
        //     else
        //     {
        //         currentSpeed = movementSpeed;
        //     }
        // }
        // else if (!Input.GetKey(KeyCode.LeftShift))
        // {
        //     stamina += Time.deltaTime;
        //     currentSpeed = movementSpeed;
        // }
	}

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("Jump", false);
    }
}
