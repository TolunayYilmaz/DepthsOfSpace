using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    float maxSpeed;
    float speedUp;
    bool move=true;
    void Start()
    {
        speed = 0.5f;
        maxSpeed = 2f;
        speedUp = 0.1f;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            MovingCam();
        }
    }
    void MovingCam()
    {
        transform.position +=transform.up*speed * Time.deltaTime;
        speed+=speedUp*Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        Debug.Log(speed);
    }


}
