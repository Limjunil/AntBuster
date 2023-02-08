using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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


    private Image antGuage = default;

    public int currentHp = default;
    public int maxHp = default;
    public float antAmount = default;

    public bool isAntDie = false;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = 100;
        maxHp = 100;


        moveSpeed = 80f;
        moveVelocy = Vector3.zero;
        cakeChk = false;
        isAntDie = false;

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

        GameObject antGuageImage = gameObject.FindChildObj("AntGuage");
        GameObject realAntGuage = antGuageImage.FindChildObj("AntGuage_Front");
        antGuage = realAntGuage.GetComponentMust<Image>();

        GameObject gameManager_ = GFunc.GetRootObj("GameManager");
        gameManager = gameManager_.GetComponentMust<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isAntDie == true)
        {
            return;
        }

        antAmount = currentHp / (float)maxHp;
        antGuage.fillAmount = antAmount;



        if(antAmount <= 0)
        {
            if (cakeChk == true)
            {
                cakeAct.OnPlusCake();

                cakeChk = false;
            }

            DieAnt();
        }

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

    public void DieAnt()
    {
        // 개미의 피가 0 이하가 되면 실행

        isAntDie = true;

        antAnimator.SetTrigger("Die");

        StartCoroutine(ReStartAnt());

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            if(currentHp <= 0) { return; }
            currentHp -= 10;


        }

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
    }   // OnTriggerEnter2D()


    public IEnumerator ReStartAnt()
    {
        yield return new WaitForSeconds(1f);

        gameObject.transform.localPosition = new Vector3(-476f, 368f, 0f);
        antAnimator.SetTrigger("ReStart");
        currentHp = 100;
        isAntDie = false;

        StopCoroutine("ReStartAnt");
    }
}
