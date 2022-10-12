using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -ScreenCalculator.instance.Widht)
        {
            Vector2 term=transform.position;    
            term.x=-ScreenCalculator.instance.Widht;
            transform.position=term;
        }
        if (transform.position.x >ScreenCalculator.instance.Widht)
        {
            Vector2 term = transform.position;
            term.x = ScreenCalculator.instance.Widht;
            transform.position = term;
        }
    }
}
