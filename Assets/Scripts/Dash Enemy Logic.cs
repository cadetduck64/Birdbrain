using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using UnityEngine;

public class DashEnemyLogic : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = LayerMask.GetMask("Platform");
    private Rigidbody enemyRb;

    private float lastYaxis;

    // List<float> isStuckArr = new List<float>();
    // float stuckSum;

    // private float IsStuck() {
    // for (int i = 0; i < isStuckArr.Count - 1; i++)
    //     {
    //         stuckSum += isStuckArr[i] + isStuckArr[i + 1];
    //     };
    // return stuckSum/isStuckArr.Count;

    // }

    private IEnumerator EnemyDash() {

        yield return new WaitForSeconds(4.0f);
        //if the enemy is 5 meters from a wall jump, if not dash forward
        if (Physics.Raycast(new Ray(transform.position, new Vector3(5, 0 , 0).normalized), 7, layerMask) || enemyRb.transform.position.y == lastYaxis)
        {enemyRb.constraints = RigidbodyConstraints.FreezeAll;
        enemyRb.constraints &= ~RigidbodyConstraints.FreezePositionX; 
        enemyRb.constraints &= ~RigidbodyConstraints.FreezePositionY; 
        enemyRb.AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);}
        else
        {enemyRb.constraints = RigidbodyConstraints.FreezeAll;
        enemyRb.constraints &= ~RigidbodyConstraints.FreezePositionX; 
        enemyRb.AddForce(new Vector3(10, 0, 0), ForceMode.Impulse);
        lastYaxis = enemyRb.transform.position.y;}
        // Debug.Log("DASHING");
        new WaitForSecondsRealtime(3.0f);
        StartCoroutine(EnemyHover());
    }

    private IEnumerator EnemyHover() {
        yield return new WaitForSeconds(2.0f);
        
        enemyRb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(EnemyDash());
        
        // Physics.Raycast(new Ray(transform.position, new Vector3(5, 0 , 0)), 10, layerMask, QueryTriggerInteraction.Ignore)
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(EnemyHover());
    }

    // Update is called once per frame
    void Update()
    {
        // if (Physics.Raycast(new Ray(transform.position, new Vector3(5, 0 , 0).normalized), 7, layerMask))
        // {Debug.Log("adfg");}
    }

}
