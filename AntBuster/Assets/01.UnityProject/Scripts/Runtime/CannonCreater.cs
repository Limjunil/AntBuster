using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCreater : MonoBehaviour
{
    private bool isClicked = false;

    public GameObject CannonNormalPrefab;

    public GameObject CannonNormalAlpha;

    public GameObject CannonNormalCreateAlpha;

    public GameObject gameBoard = default;


    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;

        GameObject gameObjs = GFunc.GetRootObj("GameObjs");
        gameBoard = gameObjs.FindChildObj("GameBoard");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        isClicked = true;
        CannonNormalCreateAlpha = Instantiate(CannonNormalAlpha, transform);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 1.0f;

        CannonNormalCreateAlpha.transform.position = mousePos;
    }

    private void OnMouseDrag()
    {
        if(isClicked == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1.0f;
            CannonNormalCreateAlpha.transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        isClicked = false;

        if (CannonNormalCreateAlpha.transform.position.x < -4.5 ||
            CannonNormalCreateAlpha.transform.position.y < -2.5 
            )
        {
            Destroy(CannonNormalCreateAlpha);

            return;
        }

        Instantiate(CannonNormalPrefab, CannonNormalCreateAlpha.transform.position,
            Quaternion.identity, gameBoard.transform);

        GFunc.Log($"{CannonNormalAlpha.transform.position} 월드 포지션 값");
    }
}
