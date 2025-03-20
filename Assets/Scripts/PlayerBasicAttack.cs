using Unity.Mathematics;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {Destroy(other.gameObject);}
    }
}
