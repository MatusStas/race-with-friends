using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAngleController : MonoBehaviour
{
    public Slider sliderAngle;
    public bool isRunning = false;
    public float minValue = -90f;
    public float maxValue = 90f;
    public float offset = 2f;
    public int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRunning)
        {
            if (sliderAngle.value > maxValue-offset)
            {
                direction *= -1;
            }

            if (sliderAngle.value < minValue+offset)
            {
                direction *= -1;
            }

            sliderAngle.value += offset * direction;
        }
    }

    public void Pause()
    {
        isRunning = true;
    }

    public void Continue()
    {
        isRunning = false;
    }
}
