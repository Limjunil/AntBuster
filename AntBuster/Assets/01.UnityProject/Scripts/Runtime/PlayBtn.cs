using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }

    public void OnExitButton()
    {
        GFunc.QuitThisGame();
    }
}
