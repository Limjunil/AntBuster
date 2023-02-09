using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCannon : MonoBehaviour
{
    private bool isSettingCannon = false;

    public CannonCreater cannonCreater;

    // Start is called before the first frame update
    void Start()
    {
        isSettingCannon = false;

        GameObject uiObjs = GFunc.GetRootObj("UiObjs");
        GameObject bottLineUi = uiObjs.FindChildObj("BottLineUi");
        GameObject tankBtn = bottLineUi.FindChildObj("TankBtn");
        cannonCreater = tankBtn.GetComponentMust<CannonCreater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NoArea" ||
            collision.tag == "AntCave" ||
            collision.tag == "Cannon" ||
            collision.tag == "Wall" )
        {
            if (isSettingCannon == true) { return; }

            Destroy(gameObject);
            cannonCreater.OnDestroyAlpha();
            cannonCreater.OnReturnMoney();
            GFunc.Log("올바른 위치가 아님");
        }

        else
        {
            OnSetting();

        }
    }

    public void OnSetting()
    {
        isSettingCannon = true;
    }


}
