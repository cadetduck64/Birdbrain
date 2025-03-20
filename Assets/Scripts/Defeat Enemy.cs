using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {Destroy(transform.parent.gameObject); other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        Debug.Log("HIT");
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Destroy(gameObject);
    // }
}
