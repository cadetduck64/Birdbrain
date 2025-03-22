using System;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SidewallLogic : MonoBehaviour
{
    GameManager gameManagerVariable;

    GameObject playerGameObject;

    Rigidbody playerRb;

    PlayerController playerController;

    public float stuckParameter;

    public float unstickDistance;


    private void StuckFailsafe() {        
        StartCoroutine(UnstickEntity());
    }

     IEnumerator UnstickEntity() {
        yield return new WaitForSeconds(0.01f);
        Debug.Log("START");
        Debug.Log(Physics.Raycast(new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + stuckParameter, 0), playerGameObject.transform.TransformDirection(Vector3.down), stuckParameter, LayerMask.GetMask("Platform")));
        Debug.DrawLine(playerGameObject.transform.position, new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + stuckParameter, 0), Color.red, 999);
        if (
            Physics.Raycast(new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + stuckParameter, 0), playerGameObject.transform.TransformDirection(Vector3.down), stuckParameter, LayerMask.GetMask("Platform"))
            || Physics.Raycast(new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y, 0), playerGameObject.transform.TransformDirection(Vector3.up), stuckParameter, LayerMask.GetMask("Platform"))
        )
        {
        if (playerController.isHovering)
        {playerController.isHovering = false;}
        playerGameObject.transform.position = new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + unstickDistance, 0);
        Debug.Log("MOVING");
        yield return UnstickEntity();} 
        else
        {yield break;}
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.position.x < 0 && !other.CompareTag("Floor") && !other.CompareTag("Hurtbox"))
        {other.transform.position = new Vector3(14, other.gameObject.transform.position.y , other.gameObject.transform.position.z); 
        if (other.gameObject.CompareTag("Player"))
        gameManagerVariable.EnableInvincibility(other.gameObject, 1, LayerMask.GetMask("Enemy", ""));
        StuckFailsafe();
        }

        else if (other.transform.position.x > 0 && !other.CompareTag("Floor") && !other.CompareTag("Hurtbox"))
        {other.transform.position = new Vector3(-14, other.gameObject.transform.position.y , other.gameObject.transform.position.z);
        if (other.gameObject.CompareTag("Player"))
        StuckFailsafe();
        gameManagerVariable.EnableInvincibility(other.gameObject, 1, LayerMask.GetMask("Enemy", ""));
        }
    }

    void Start()
    {
        unstickDistance = 0.1f;
        stuckParameter = 1.8f;
        gameManagerVariable = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerGameObject = GameObject.Find("Player");

        playerController = playerGameObject.GetComponent<PlayerController>();
        playerRb = playerGameObject.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Physics.Raycast(new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + stuckParameter, 0), playerGameObject.transform.TransformDirection(Vector3.down), stuckParameter, LayerMask.GetMask("Platform")));
        
        // Debug.Log(new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + stuckParameter, 0));
        // Debug.DrawLine(playerGameObject.transform.position, new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + stuckParameter, 0), Color.white, 1);

        // Debug.DrawLine(playerGameObject.transform.position, new Vector3(playerGameObject.transform.position.x + stuckParameter, playerGameObject.transform.position.y, 0), Color.white, 1);
    }
    }
