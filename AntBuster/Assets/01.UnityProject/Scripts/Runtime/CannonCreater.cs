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

    public OutCannon outCannon = default;

    public List<GameObject> cannonList = default;


    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;

        GameObject gameObjs = GFunc.GetRootObj("GameObjs");
        gameBoard = gameObjs.FindChildObj("GameBoard");

        cannonList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        float playerMoney = PlayerPrefs.GetFloat("moneyNow");

        if (30 <= playerMoney)
        {
            playerMoney -= 30f;

            PlayerPrefs.SetFloat("moneyNow", playerMoney);
        }
        else { return; }


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
            CannonNormalCreateAlpha.transform.position.y < -2.5 )
        {
            OnReturnMoney();
            Destroy(CannonNormalCreateAlpha);

            return;
        }

        //for(int i = 0; i < cannonList.Count; i++)
        //{
        //    cannonList[i].transform.position
        //}

        GameObject tempCannon =
        Instantiate(CannonNormalPrefab, CannonNormalCreateAlpha.transform.position,
            Quaternion.identity, gameBoard.transform);

        cannonList.Add(tempCannon);

        //outCannon = CannonNormalPrefab.GetComponentMust<OutCannon>();

        //outCannon.OnSetting();

    }

    public void OnDestroyAlpha()
    {
        Destroy(CannonNormalCreateAlpha);
    }

    public void OnReturnMoney()
    {
        float playerMoney = PlayerPrefs.GetFloat("moneyNow");
        playerMoney += 30;
        PlayerPrefs.SetFloat("moneyNow", playerMoney);
    }

}
