using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    private bool isClick = false;

    private Transform pauseUiTxt;


    // Start is called before the first frame update
    void Start()
    {
        isClick = false;

        GameObject uiObjs = GFunc.GetRootObj("UiObjs");
        GameObject pauseUi = uiObjs.FindChildObj("PauseUi");

        pauseUiTxt = pauseUi.GetComponentMust<Transform>();

        pauseUiTxt.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        if (isClick == false)
        {
            Time.timeScale = 0f;
            isClick = true;

            pauseUiTxt.localScale = Vector3.one;
        }
        else
        {
            Time.timeScale = 1f;
            isClick = false;

            pauseUiTxt.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);

        }
    }

}
