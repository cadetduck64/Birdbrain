using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);
    //     // Debug.Log("BUMPED");
    //     if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
    //     collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(20, 20, 20), ForceMode.Impulse);
    //     Debug.Log("BUMPED");
    // }

    void OnTriggerStay(Collider other)
    {
        // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1), ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
