using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    [SerializeField] GameObject gold;
    // Start is called before the first frame update
     public void goldActive()
    {
        gold.SetActive(true);   
    }
    public void goldNotActive()
    {
        gold.SetActive(false);
    }
}
