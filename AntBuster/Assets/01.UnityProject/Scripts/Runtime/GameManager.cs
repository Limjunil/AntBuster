using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject PointNowTxtObj = default;

    private GameObject MoneyTxtObj = default;

    private GameObject LevelTxtObj = default;

    private float pointNow = default;

    private float moneyNow = default;

    private int level = default;
    private int levelChk = default;


    private bool isGameOver = false;

    private bool isMoneyChk = false;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isMoneyChk = false;
        pointNow = 0;
        moneyNow = 300;
        level = 1;
        levelChk = 1;

        GameObject uiObjs_ = GFunc.GetRootObj("UiObjs");
        GameObject scores = uiObjs_.FindChildObj("Scores");
        PointNowTxtObj = scores.FindChildObj("Points");
        MoneyTxtObj = scores.FindChildObj("Money");
        LevelTxtObj = scores.FindChildObj("Level");

        SetLevel();

    }

    // Update is called once per frame
    void Update()
    {
        SetPoint();

        SetMoney();
    }



    public void SetPoint()
    {
        
        float pointNowVal = PlayerPrefs.GetFloat("pointNow");

        GFunc.SetTmpText(PointNowTxtObj, $"{pointNowVal}");
    }

    public void SetMoney()
    {
        if (isMoneyChk == true) { /* Do Nothing */ }
        else 
        {
            PlayerPrefs.SetFloat("moneyNow", moneyNow);
        }


        float moneyNowVal = PlayerPrefs.GetFloat("moneyNow");

        GFunc.SetTmpText(MoneyTxtObj, $"{moneyNowVal}");

        isMoneyChk = true;
    }

    public void OnDieAntCnt()
    {

        levelChk++;

        if(level <= levelChk)
        {
            levelChk -= level;

            level++;
        }

        SetLevel();
    }

    public void SetLevel()
    {
        PlayerPrefs.SetInt("level", level);

        float levelVal = PlayerPrefs.GetInt("level");

        GFunc.SetTmpText(LevelTxtObj, $"{levelVal}");
    }
}
