using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    Slider jumpSlider;
    void Start()
    {
        jumpSlider = GetComponent<Slider>();
        jumpSlider.value = 1.0f;
    }

   public void JumpSlider(int maxValue, int currentValue)

    {
        int sliderValue = maxValue - currentValue;
        jumpSlider.maxValue = maxValue; 
        jumpSlider.value = sliderValue;

    }

}
