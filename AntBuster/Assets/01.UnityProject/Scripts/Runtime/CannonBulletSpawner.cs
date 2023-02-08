using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBulletSpawner : MonoBehaviour
{
    public GameObject cannonBulletPrefab;

    // 총알 생성 주기 : 초당 몇발
    public float spawnCannonBullet = default;

    private Transform target = default;

    // 최근 생성 시점에서 지난 시간
    private float timeAfterSpawn = default;

    // 총알 미리 만들기
    public GameObject[] cannonBullets;

    private int bulletCount = default;


    private int bulletUseCnt = default;

    private Vector3[] antCannonChk = default;

    private float shortDis = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        bulletUseCnt = 0;

        spawnCannonBullet = 0.3f;

        bulletCount = 20;
        cannonBullets = new GameObject[bulletCount];
        antCannonChk = new Vector3[6];

        //target = GameObject.Find("Ant").transform;

        Vector3 cannonBulletFirstPos = new Vector3(-1000f, 0, 0);


        // 총알 바깥에 만들어 두기
        for(int i = 0; i < bulletCount; i++)
        {
            cannonBullets[i] = Instantiate(cannonBulletPrefab, cannonBulletFirstPos,
                Quaternion.identity, gameObject.transform);

            cannonBullets[i].SetActive(false);

        }


    }

    // Update is called once per frame
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ant")
        {

            if (spawnCannonBullet <= timeAfterSpawn)
            {
                GameObject[] targetList = GameObject.FindGameObjectsWithTag("Ant");
                               
                target = targetList[0].transform;

                // 첫 번째를 기준으로 대상 잡기
                shortDis = Vector3.Distance(gameObject.transform.localPosition,
                    targetList[0].transform.localPosition);

                foreach(GameObject found in targetList)
                {
                    float Distance = Vector3.Distance(
                        gameObject.transform.localPosition,
                        found.transform.localPosition);

                    if(Distance < shortDis)
                    {
                        target = found.transform;
                        shortDis = Distance;
                    }
                }

                // 거리 계산 잘하는 지 확인
                GFunc.Log($"{target} 이며, {shortDis} 가 가장 짧습니다.");


                cannonBullets[bulletUseCnt].SetActive(true);

                timeAfterSpawn = 0;

                cannonBullets[bulletUseCnt].transform.localPosition =
                    gameObject.transform.localPosition;

                Vector2 direction = (target.transform.localPosition -
                    gameObject.transform.localPosition).normalized;

                float localAngle = Mathf.Atan2(direction.y, direction.x) *
                    Mathf.Rad2Deg;


                Quaternion angleAxis = Quaternion.AngleAxis(
                    localAngle - 90f, Vector3.forward);

                Quaternion rotation = Quaternion.Slerp(transform.rotation,
                    angleAxis, 0.3f);

                transform.rotation = rotation;
                cannonBullets[bulletUseCnt].transform.rotation = rotation;

                bulletUseCnt++;

                if (bulletUseCnt == 20)
                {
                    bulletUseCnt = 0;
                }

            }
        }
    }
}
