using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnim;
    Vector2 velocity;
    Vector2 playerTransformScale;
    [SerializeField]private float speed;
    [SerializeField]private float speedUp;
    [SerializeField] private float speedDown;    


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();  
        playerTransformScale = GetComponent<Transform>().localScale;    
    }

    void Update()
    {
        KeyboardControl();
    }
    void KeyboardControl()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0)
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
       else if(horizontalInput == 0)
       {
           velocity.x = Mathf.MoveTowards(velocity.x, 0, speedDown * Time.deltaTime);
           playerAnim.SetBool("Walk", false);
       }
       
        transform.Translate(velocity * Time.deltaTime);
        transform.localScale = playerTransformScale;
    }
}
