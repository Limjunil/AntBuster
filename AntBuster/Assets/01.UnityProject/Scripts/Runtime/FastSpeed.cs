using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpeed : MonoBehaviour
{
    private int clickCount = default;

    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpeedUp()
    {
        clickCount++;

        if (clickCount == 3)
        {
            clickCount = 0;
        }


        switch (clickCount)
        {
            case 0:
                Time.timeScale = 1.0f;
                break;
            case 1:
                Time.timeScale = 2.0f;
                break;
            case 2:
                Time.timeScale = 3.0f;
                break;
        }

    }
}
