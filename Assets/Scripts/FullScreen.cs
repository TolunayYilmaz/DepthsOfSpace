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
        float spriteGenişlik = spriteRenderer.size.x;
        float ekranyükseklik=Camera.main.orthographicSize*2f;
        float ekrangenişlik = ekranyükseklik / Screen.height * Screen.width;
        tempScale.x = ekrangenişlik / spriteGenişlik;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
