using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    private float moveSpeed = default;

    public int rotateSpeed;
    private Vector3 moveVelocy = Vector3.zero;

    [SerializeField]
    private RectTransform target1;

    private RectTransform antRect;

    private Transform target2;

    public Rigidbody2D rigidbodyAnt;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4f;
        moveVelocy = Vector3.zero;
        rotateSpeed = 10;


        rigidbodyAnt = gameObject.GetComponentMust<Rigidbody2D>();

        GameObject gameObjs = GFunc.GetRootObj("GameObjs");
        GameObject gameBoard = gameObjs.FindChildObj("GameBoard");
        GameObject cake = gameBoard.FindChildObj("Cake");
        GameObject noArea2 = gameBoard.FindChildObj("NoArea2");

        target1 = cake.GetComponentMust<RectTransform>();
        target2 = noArea2.transform;

        antRect = gameObject.GetComponentMust<RectTransform>();

        float angleDegree = 
            Vector2.Angle(antRect.localPosition, target1.localPosition);

        GFunc.Log($"{angleDegree} 값입니다.");

        //Vector3 antLookCake = Quaternion.LookRotation(direction).eulerAngles;
        //antLookCake.y = 0f;

        //gameObject.transform.rotation = Quaternion.Euler(antLookCake);
    }

    // Update is called once per frame
    void Update()
    {
        //if(target1 != null)
        //{
        //    Vector2 direction = (target1.anchoredPosition -
        //        antRect.anchoredPosition).normalized;

        //    Vector3 antLookCake =  Quaternion.LookRotation(direction, Vector3.forward).eulerAngles;
        //    antLookCake.y = 0f;
        //    //Quaternion.Euler(antLookCake);


        //    gameObject.transform.rotation = Quaternion.Euler(antLookCake);

        //}

        //moveVelocy = new Vector3(0f, 0.1f, 0f);
        //float xRota = gameObject.transform.rotation.x;
        //gameObject.transform.rotation = new Quaternion(xRota, 0f, 0f, 0f);

        //transform.position += moveVelocy * moveSpeed * Time.deltaTime;
    }

}
