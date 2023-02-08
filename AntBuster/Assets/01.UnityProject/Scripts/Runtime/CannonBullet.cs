using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{

    public float cannonSpeed = default;

    private Rigidbody2D cannonBulletRigid = default;

    // Start is called before the first frame update
    void Start()
    {
        cannonSpeed = 4f;
        cannonBulletRigid = gameObject.GetComponentMust<Rigidbody2D>();

        
        //StartCoroutine(OffCannonBullet());
    }

    // Update is called once per frame
    void Update()
    {
        cannonBulletRigid.velocity = transform.up * cannonSpeed;

        GFunc.Log($"transform.forward : {transform.up}, cannonSpeed : {cannonSpeed}");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ant" || collision.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }


    public IEnumerator OffCannonBullet()
    {
        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);

    }
}
