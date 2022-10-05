using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
 
    PolygonCollider2D planeRb;
    private bool planeMovement = true;
    public bool PlaneMovement
    {
        get { return planeMovement; }
        set { planeMovement = value; }
    }

    void Start()
    {
         planeRb=GetComponent<PolygonCollider2D>();    
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
            float forcePlane = Mathf.PingPong(Time.time, 3f);
            Debug.Log(forcePlane + " plane kuvvet");
            transform.position = new Vector2(forcePlane, transform.position.y);
        }
 
    }
}
