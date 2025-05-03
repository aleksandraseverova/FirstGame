using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Animator anim;
    Rigidbody rb;
    Vector3 direction;
    float jumpForce = 7f;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;     
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(new Vector3 (0, jumpForce, 0), ForceMode.Impulse);
        }

        if(direction.x !=0 || direction.z !=0)
        {
            anim.SetBool("Walk", true);
            //Если источник звука не воспроизводит звук и мы на земле, то...
            // if (!characterSounds.isPlaying && isGrounded)
            // {
            //     //Включаем звук
            //     characterSounds.Play();
            // }
        }
        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Talking", true);

            //Отключаем звук, если мы останавились
            // characterSounds.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
