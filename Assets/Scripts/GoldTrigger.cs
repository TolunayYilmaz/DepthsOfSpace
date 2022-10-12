using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Legs")
        {
            Debug.Log("ayak");
            GetComponentInParent<Gold>().goldNotActive();
            FindObjectOfType<Score>().GoldCalculation(1);
        }
    }
}
