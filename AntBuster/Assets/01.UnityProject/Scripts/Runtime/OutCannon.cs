using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCannon : MonoBehaviour
{

    public CannonCreater cannonCreater;

    // Start is called before the first frame update
    void Start()
    {
        GameObject uiObjs = GFunc.GetRootObj("UiObjs");
        GameObject bottLineUi = uiObjs.FindChildObj("BottLineUi");
        GameObject tankBtn = bottLineUi.FindChildObj("TankBtn");
        cannonCreater = tankBtn.GetComponentMust<CannonCreater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NoArea" ||
            collision.tag == "Cannon" ||
            collision.tag == "AntCave" ||
            collision.tag == "Wall"
            )
        {
            Destroy(gameObject);
            cannonCreater.OnDestroyAlpha();
            cannonCreater.OnReturnMoney();
            GFunc.Log("올바른 위치가 아님");
        }
    }

}
