using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverClick : MonoBehaviour, IPointerClickHandler
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnClickAct()
    //{
        
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        GFunc.LoadScene(GData.SCENE_NAME_TITLE);

    }
}
