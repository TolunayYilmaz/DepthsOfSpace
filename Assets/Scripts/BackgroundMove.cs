using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    float distance = 10.24f;
    float backgroundPos;
    void Start()
    {
        backgroundPos = transform.position.y;
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y > transform.position.y + distance)
        {
            BackgroundUp();
        }
    }

    void BackgroundUp()
    {
        backgroundPos += 2 * distance;
        transform.position = transform.up * backgroundPos;
        
    }
}
