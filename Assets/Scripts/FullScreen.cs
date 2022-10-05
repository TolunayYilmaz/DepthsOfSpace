using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float spriteGeni�lik = spriteRenderer.size.x;
        float ekrany�kseklik=Camera.main.orthographicSize*2f;
        float ekrangeni�lik = ekrany�kseklik / Screen.height * Screen.width;
        tempScale.x = ekrangeni�lik / spriteGeni�lik;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
