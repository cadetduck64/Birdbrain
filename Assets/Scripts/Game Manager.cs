// using System;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables
    private bool isPaused = false;

    private int score;

    private GameObject playerRb;

    public List<GameObject> EnemyList;

    public List<GameObject> PlatformList;
    
    public GameObject coin;

    public GameObject pauseMenu;

    //UI variables
    public TextMeshProUGUI scoreText;
    // TextMeshProUGUI health;
    
    //methods/functions

    public void PauseGame() {
        if (isPaused == true) {Time.timeScale = 1; isPaused = false;}
        else if (isPaused == false) {Time.timeScale = 0; isPaused = true;}
        pauseMenu.SetActive(isPaused);
        Debug.Log(isPaused);
    }

    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    private void RearrangePlatforms() {
        
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Floor");

        int[] xMatrix = {UnityEngine.Random.Range(-15, -11), UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(15, 11)};
        int[] yMatrix = {UnityEngine.Random.Range(-2, 4)};


        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = new Vector3 (xMatrix[i], UnityEngine.Random.Range(-2, 4), 2);
        }
        // foreach (var item in gameObjects)
        // {
        //     Debug.Log(Array.IndexOf(gameObjects, item));
        //     item.transform.position = new Vector3 (UnityEngine.Random.Range(-15, 15), UnityEngine.Random.Range(-2, 4), 1);
        // }

        // IEnumerator MovePlats() {
        //     yield return new WaitForSeconds(2);
        //     foreach (var item in gameObjects)
        // {
        //     new WaitForSeconds(2);
        //     item.transform.position = new Vector3 (item.transform.position.x, item.transform.position.y, 1);
        // }
        // }
    }


    private Vector3 generateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-13, 3);
        float spawnPosY = UnityEngine.Random.Range(-5, 9);
        float spawnAway =  spawnPosX + playerRb.transform.position.x;
        if (spawnAway < -14 || spawnAway > 14)
        {spawnAway = 13 * playerRb.transform.position.x / playerRb.transform.position.x;}
        Vector3 randomPos = new Vector3(spawnAway, spawnPosY , 0);

        return randomPos;
    }

    public void SpawnCoin() {
        Instantiate(coin, new Vector3(generateSpawnPosition().x, generateSpawnPosition().y, 0), coin.transform.rotation);
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = "Score: " + score;
        if (score % 5 == 0)
        {RearrangePlatforms();}
        SpawnEnemy();
        Debug.Log(score);
    }

    public void SpawnEnemy() {
        // EnemySpawnerLogic enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawnerLogic>();
        GameObject[] enemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");
        Debug.Log(enemySpawner);
        for (int i = 0; i < enemySpawner.Length; i++)
        {
            enemySpawner[i].GetComponent<EnemySpawnerLogic>().EnemySpawnerFunc();
        }
        
        // Instantiate(EnemyList[UnityEngine.Random.Range(0, EnemyList.Count)], new Vector3(0,0,0), Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GameObject.Find("Player");
        pauseMenu = GameObject.Find("Pause Menu");
        isPaused = false;
        pauseMenu.SetActive(false);
        // PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(playerRb.transform.position);
        
    }
}
