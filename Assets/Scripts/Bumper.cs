using System;
using System.Collections;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class script : MonoBehaviour
{
    // public float stuckVelocity;
    // public float repelForce;

    // private float entityDirection;


    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start() {
    //     if (gameObject.transform.position.x < -15 || transform.position.x > 15)
    //     {Destroy(gameObject);}
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag("Sidewall"))
    //     {Destroy(gameObject);}

    //     // Vector3 bumpForce = other.gameObject.GetComponent<Rigidbody>().linearVelocity;
    //     // Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();

    //     // entityDirection = bumpForce.x;

    //     // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(bumpForce.x *= -repelForce * otherRb.mass * 1.2f, 0, 0), ForceMode.Impulse);

    //     // StartCoroutine(CheckIfStuck(bumpForce.x, otherRb));


    //     // Debug.Log(other.gameObject.GetComponent<Rigidbody>().linearVelocity);
    //     // Debug.Log("BUMPED");
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     Vector3 bumpForce = other.gameObject.GetComponent<Rigidbody>().linearVelocity;
    //     Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
        
    //     StartCoroutine(CheckIfStuck(entityDirection, otherRb));


        // float repelEquation = bumpForce.x *= -repelForce * -otherRb.mass;

        // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Ceil(repelEquation), Mathf.Ceil(repelEquation), 0), ForceMode.Impulse);
        
        // Debug.Log(repelEquation);

        // Debug.Log(other.gameObject.GetComponent<Rigidbody>().linearVelocity);
        // Debug.Log("BUMPED");
    // }
    
    // private IEnumerator CheckIfStuck(float direction, Rigidbody entity) {
    //     new WaitForSeconds(3);
    //     if (direction > 1)
    //     {entity.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(direction * 0.1f + entity.mass, 0 , 0), ForceMode.Impulse);}
    //     else if (direction < 1)
    //     {entity.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-direction * 0.1f + entity.mass, 0 , 0), ForceMode.Impulse);}
    //     Debug.Log(direction);
    //     yield return null;
    // }


    // Update is called once per frame
}
