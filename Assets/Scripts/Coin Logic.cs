using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    private GameManager gameManagerVariable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    // playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        gameManagerVariable = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log(other.tag);
            if (other.CompareTag("Floor") || other.CompareTag("Bumper"))
            {Destroy(gameObject); gameManagerVariable.SpawnCoin();  return;}
            else if(other.CompareTag("Player"))
            {Destroy(gameObject); gameManagerVariable.SpawnCoin(); Debug.Log("Coin Collected"); gameManagerVariable.IncreaseScore(); return;}
        }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }
}
