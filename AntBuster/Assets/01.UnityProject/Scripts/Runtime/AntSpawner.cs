using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;

    public GameObject[] antSpawn;

    public int spawnCount = default;

    public Vector3 antFirstPos = default;
    public Vector3 antSecondPos = default;

    public int createCount = default;

    public GameObject startCount = default;
    public int startChk = default;


    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 6;
        antFirstPos = new Vector3(-2000f, 0f, 0f);
        antSecondPos = new Vector3(-476f, 368f, 0f);
        createCount = 0;
        startChk = 9;

        antSpawn = new GameObject[spawnCount];


        for(int i = 0; i < spawnCount; i++)
        {
            antSpawn[i] = Instantiate(antPrefab, antFirstPos,
                Quaternion.identity, gameObject.transform);

            antSpawn[i].name = $"AntClone{i}";
        }

        GameObject gameObjs = GFunc.GetRootObj("GameObjs");
        GameObject gameBoard = gameObjs.FindChildObj("GameBoard");
        GameObject noArea2 = gameBoard.FindChildObj("NoArea2");
        startCount = noArea2.FindChildObj("StartCount");

        StartCoroutine(CountTen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator CreateAntSix()
    {
        while (createCount < 6)
        {
            antSpawn[createCount].transform.localPosition = antSecondPos;

            yield return new WaitForSeconds(4f);
            createCount++;
            GFunc.Log("createCount");

        }

        if(createCount == 6)
        {
            StopCoroutine("CreateAntSix");

            GFunc.Log("sss");
        }
    }

    public IEnumerator CountTen()
    {
        while (-1 < startChk)
        {
            GFunc.SetTmpText(startCount, $"{startChk}");

            yield return new WaitForSeconds(1f);

            startChk--;
        }

        if (startChk == -1)
        {
            startCount.SetActive(false);

            StopCoroutine("CountTen");


            StartCoroutine(CreateAntSix());
            
        }
    }


}
