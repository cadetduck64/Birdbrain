using UnityEngine;

public class CollectCoinCameraLogic : MonoBehaviour
{
    public float offset;
    private GameObject playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //between -10(3.5 camera position) and -7.7 (1.2 camera position)
        // Debug.Log(playerPosition.transform.position.y);
        // gameObject.transform.position = new Vector3(0, playerPosition.transform.position.y - offset, -11.42f );
        gameObject.transform.position = new Vector3(0, Mathf.Clamp(playerPosition.transform.position.y + 0.5f, 1.42f, 3.5f), -11.42f );
    }
}
