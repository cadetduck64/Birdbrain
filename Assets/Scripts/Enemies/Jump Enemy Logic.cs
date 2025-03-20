using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float enemyJumpHeight;

    public float enemySpeed;
    private Rigidbody enemyRb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // enemyRb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(EnemyJump());
    }

    //Destroys player when in contact
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy(collision.gameObject);
            // Debug.Log(collision.GetContacts(List))
        }
    }

    // Update is called once per frame
    void Update()
    {

        enemyRb = GetComponent<Rigidbody>();
        enemyRb.AddForce(new Vector3(enemySpeed, 0, 0), ForceMode.Impulse);

        if (enemyRb.linearVelocity.x > 5)
        {enemyRb.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);}
        else if (enemyRb.linearVelocity.x < -5)
        {enemyRb.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);}
    }

    private IEnumerator EnemyJump() {
        yield return new WaitForSeconds(4.0f);
        // Debug.Log("ENEMY JUMPED");
        enemyRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        StartCoroutine(EnemyJump());
    }
}
