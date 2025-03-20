using Unity.VisualScripting;
using UnityEngine;

public class SidewallLogic : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other) {
        if (other.transform.position.x < 0 && !other.CompareTag("Floor") && !other.CompareTag("Hurtbox"))
        {other.transform.position = new Vector3(14, other.gameObject.transform.position.y , other.gameObject.transform.position.z);}
        else if (other.transform.position.x > 0 && !other.CompareTag("Floor") && !other.CompareTag("Hurtbox"))
        {other.transform.position = new Vector3(-14, other.gameObject.transform.position.y , other.gameObject.transform.position.z);
        //addforce to maintain speed
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
