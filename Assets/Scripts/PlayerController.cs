using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;
    Vector2 velocity;
    Vector2 playerTransformScale;
    [SerializeField] private float speed;
    [SerializeField] private float speedUp;
    [SerializeField] private float speedDown;
    [SerializeField] private float force;

    [SerializeField] private int maxJump = 3;
    [SerializeField] private int plusJump = 0;
    bool jumper;

    Joystick joystick;
    JoystickButton joystickButton;
    public int PlusJump
    {
        set
        {
            plusJump = value;
        }
    }


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerTransformScale = GetComponent<Transform>().localScale;
    }

    void Update()
    {


    #if UNITY_EDITOR
        KeyboardControl();
    #else
        JoystickControl();
    #endif
    }
    void KeyboardControl()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalInput * speed, speedUp * Time.deltaTime);
            playerAnim.SetBool("Walk", true);
            playerTransformScale.x = 0.4f;
        }

        if (horizontalInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalInput * speed, speedUp * Time.deltaTime);
            playerAnim.SetBool("Walk", true);
            playerTransformScale.x = -0.4f;
        }
        else if (horizontalInput == 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, speedDown * Time.deltaTime);
            playerAnim.SetBool("Walk", false);
        }

        transform.Translate(velocity * Time.deltaTime);
        transform.localScale = playerTransformScale;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartJump();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
        }
    }

    void JoystickControl()
    {
        float horizontalInput = joystick.Horizontal;
        if (horizontalInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalInput * speed, speedUp * Time.deltaTime);
            playerAnim.SetBool("Walk", true);
            playerTransformScale.x = 0.4f;
        }

        if (horizontalInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalInput * speed, speedUp * Time.deltaTime);
            playerAnim.SetBool("Walk", true);
            playerTransformScale.x = -0.4f;
        }
        else if (horizontalInput == 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, speedDown * Time.deltaTime);
            playerAnim.SetBool("Walk", false);
        }

        transform.Translate(velocity * Time.deltaTime);
        transform.localScale = playerTransformScale;
        if (joystickButton.jump == true && jumper == false)
        {
            jumper = true;
            StartJump();

        }
        else if (joystickButton.jump == false && jumper == true)
        {
            jumper = false;
            StopJump();

        }
    }
    void StartJump()
    {
        if (plusJump < maxJump)
        {
            playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            playerAnim.SetBool("Jump", true);
            FindObjectOfType<SliderController>().JumpSlider(maxJump, plusJump);
        }

    }
    void StopJump()
    {
        playerAnim.SetBool("Jump", false);
        plusJump++;
        FindObjectOfType<SliderController>().JumpSlider(maxJump, plusJump);
    }
    public void ResetJump()
    {
        plusJump = 0;
        FindObjectOfType<SliderController>().JumpSlider(maxJump, plusJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("DeadLine"))
       {
           FindObjectOfType<GameManager>().GameOver();
       }
    }
}
