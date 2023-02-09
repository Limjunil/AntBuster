using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CakeAct : MonoBehaviour
{
    public int cakeCount = default;

    public Sprite[] cakeSprites;

    public Image cakeImage;

    public Color cakeColor;

    // Start is called before the first frame update
    void Start()
    {
        cakeCount = 8;

        //cakeSprites = Sprite[cakeCount];
        cakeImage = gameObject.GetComponentMust<Image>();

        cakeColor = cakeImage.color;
    }

    // Update is called once per frame
    void Update()
    {

        switch (cakeCount)
        {
            case 8:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[0];
                break;

            case 7:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[1];

                break;
            case 6:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[2];
                break;
            case 5:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[3];
                break;
            case 4:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[4];
                break;
            case 3:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[5];
                break;
            case 2:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[6];
                break;
            case 1:
                cakeColor.a = 255f;
                cakeImage.color = cakeColor;
                cakeImage.sprite = cakeSprites[7];
                break;
            default:
                cakeColor.a = 0f;
                cakeImage.color = cakeColor;
                break;
        }
    }


    public void OnMinusCake()
    {
        cakeCount -= 1;
    }

    public void OnPlusCake()
    {
        cakeCount += 1; 

    }
}
