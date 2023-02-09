using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject PointNowTxtObj = default;

    private GameObject MoneyTxtObj = default;

    private GameObject LevelTxtObj = default;

    private Transform GameOverTxt = default;

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

        GameObject topUi_ = GFunc.GetRootObj("TopUi");


        GameObject GameOver = topUi_.FindChildObj("GameOver");



        GameOverTxt = GameOver.GetComponentMust<Transform>();

        GameOverTxt.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);

        PlayerPrefs.SetFloat("pointNow", pointNow);


    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver == true)
        {
            GameOverTxt.localScale = Vector3.one;
            Time.timeScale = 0F;
        }

        SetLevel();

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

    }

    public void SetLevel()
    {
        PlayerPrefs.SetInt("level", level);

        float levelVal = PlayerPrefs.GetInt("level");

        GFunc.SetTmpText(LevelTxtObj, $"{levelVal}");
    }

    public void IsGameOver()
    {
        isGameOver = true;
    }
}
