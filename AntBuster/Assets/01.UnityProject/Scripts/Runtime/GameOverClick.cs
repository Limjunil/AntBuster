using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAct()
    {
        GFunc.LoadScene(GData.SCENE_NAME_TITLE);
    }
}
