using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    private float moveSpeed = default;

    private Vector3 moveVelocy = Vector3.zero;

    [SerializeField]
    private RectTransform target1;

    private RectTransform antRect;

    private RectTransform target2;

    public Rigidbody2D rigidbodyAnt;

    public CakeAct cakeAct = default;

    public Animator antAnimator;

    public bool cakeChk = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 80f;
        moveVelocy = Vector3.zero;
        cakeChk = false;

        rigidbodyAnt = gameObject.GetComponentMust<Rigidbody2D>();

        GameObject gameObjs = GFunc.GetRootObj("GameObjs");
        GameObject gameBoard = gameObjs.FindChildObj("GameBoard");
        GameObject cake = gameBoard.FindChildObj("Cake");
        GameObject noArea2 = gameBoard.FindChildObj("NoArea2");

        target1 = cake.GetComponentMust<RectTransform>();
        target2 = noArea2.GetComponentMust<RectTransform>();

        antRect = gameObject.GetComponentMust<RectTransform>();
        cakeAct = cake.GetComponentMust<CakeAct>();

        antAnimator = gameObject.GetComponentMust<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cakeChk == true)
        {
            Vector2 direction_2 = (target2.localPosition - antRect.localPosition).normalized;

            float localAngle2 = Mathf.Atan2(direction_2.y, direction_2.x) * Mathf.Rad2Deg - 90.0f;


            transform.rotation = Quaternion.AngleAxis(localAngle2, Vector3.forward);

            Vector3 addDirect2 = direction_2 * moveSpeed * Time.deltaTime;

            transform.localPosition += addDirect2;
        }
        else
        {

            Vector2 direction_ = (target1.localPosition - antRect.localPosition).normalized;

            float localAngle = Mathf.Atan2(direction_.y, direction_.x) * Mathf.Rad2Deg - 90.0f;


            transform.rotation = Quaternion.AngleAxis(localAngle, Vector3.forward);

            Vector3 addDirect = direction_ * moveSpeed * Time.deltaTime;

            transform.localPosition += addDirect;

        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cake")
        {
            if (cakeAct.cakeCount == 0)
            {
                cakeChk = true;
            }
            else
            {

                cakeAct.OnMinusCake();

                antAnimator.SetTrigger("GetCake");

                cakeChk = true;
            }
        }

        if(collision.tag == "AntCave")
        {
            if (cakeChk == true)
            {
                antAnimator.SetTrigger("ReStart");

                cakeChk = false;
            }
        }
    }
}