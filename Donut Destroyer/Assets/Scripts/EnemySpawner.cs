using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyType;
    //private GameObject spawnLocation;

    public int livingEnemies;
    public Transform spawnPoint;
    public int count;
    public float rate;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = rate;
        //spawnLocation = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        livingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (livingEnemies <= count && timer <= 0)
        {
            timer = rate;
            GameObject enemy = Instantiate(enemyType, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
