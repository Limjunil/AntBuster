using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CakeAct : MonoBehaviour
{
    public int cakeCount = default;

    public Sprite[] cakeSprites;

    public Image cakeImage;

    // Start is called before the first frame update
    void Start()
    {
        cakeCount = 8;

        //cakeSprites = Sprite[cakeCount];
        cakeImage = gameObject.GetComponentMust<Image>();

       

    }

    // Update is called once per frame
    void Update()
    {

        switch (cakeCount)
        {
            case 8:
                cakeImage.sprite = cakeSprites[0];
                break;

            case 7:
                cakeImage.sprite = cakeSprites[1];

                break;
            case 6:
                cakeImage.sprite = cakeSprites[2];
                break;
            case 5:
                cakeImage.sprite = cakeSprites[3];
                break;
            case 4:
                cakeImage.sprite = cakeSprites[4];
                break;
            case 3:
                cakeImage.sprite = cakeSprites[5];
                break;
            case 2:
                cakeImage.sprite = cakeSprites[6];
                break;
            case 1:
                cakeImage.sprite = cakeSprites[7];
                break;
            default:
                cakeImage.enabled = false;
                break;
        }
    }


    public void OnMinusCake()
    {
        cakeCount--;
    }

    public void OnPlusCake()
    {
        cakeCount++;
    }
}
