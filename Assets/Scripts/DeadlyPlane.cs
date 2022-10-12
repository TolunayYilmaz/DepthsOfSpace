using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPlane : MonoBehaviour
{

    BoxCollider2D planeCollider;
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
        planeCollider = GetComponent<BoxCollider2D>();
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

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (planeMovement)
        {
            float forcePlane = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;

            transform.position = new Vector2(forcePlane, transform.position.y);
        }

    }

}
