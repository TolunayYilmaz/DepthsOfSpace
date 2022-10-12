using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{

    PolygonCollider2D planeCollider;
    private bool planeMovement = false;
    float min, max;
    float randomSpeed;
    public bool PlaneMovement
    {
        get { return planeMovement; }
        set { planeMovement = value; }
    }

    void Start()
    {
        planeCollider = GetComponent<PolygonCollider2D>();
        randomSpeed = Random.Range(0.5f, 1f);
        float objectWidht = planeCollider.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            min = objectWidht;
            max = ScreenCalculator.instance.Widht - objectWidht;

        }
        else
        {
            min = -ScreenCalculator.instance.Widht + objectWidht;
            max = -objectWidht;

        }
    }

  
    void Update()
    {
        Move();
    }

    private void Move()//move in specific area
    {
        if (planeMovement)
        {
            float forcePlane = Mathf.PingPong(Time.time*randomSpeed, max - min) + min;
          
            transform.position = new Vector2(forcePlane, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Legs"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;//make a move
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerController>().ResetJump();//reset bouncing when you hit the ground
        }
    }
}
