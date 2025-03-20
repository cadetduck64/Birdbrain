using System.Collections;
using UnityEngine;

public class FlyingEnemyLogic : MonoBehaviour
{
    private Rigidbody enemyRb;

    public float enemySpeed;

    public float jumpInterval;
    private IEnumerator EnemyJump() {
        yield return new WaitForSeconds(jumpInterval);
        // Debug.Log("ENEMY JUMPED");

        enemyRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        StartCoroutine(EnemyJump());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemyJump());
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
}
