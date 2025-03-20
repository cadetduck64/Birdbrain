using UnityEngine;

public class EnemySpawnerLogic : MonoBehaviour
{
    public GameObject[] enemyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EnemySpawnerFunc() {
        Instantiate(enemyList[Random.Range(0, enemyList.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
    }
    
    void OnTriggerStay(Collider other)
    {
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, 0);
    }
}
