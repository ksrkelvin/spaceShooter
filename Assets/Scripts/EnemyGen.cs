using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnRate;
    [SerializeField] private float maxSpawnYPos = 14f;
    [SerializeField] private float maxSpawnXPos = 14f;
    [SerializeField] private int maxSpawnEnemy = 3;
    [SerializeField] private int enemyCount = 0;
    private int nextLevel = 100;


    private int xp = 0;
    [SerializeField] private int level = 1;
    private float timeToSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyGenerator();
    }

    private void EnemyGenerator()
    {
        timeToSpawn -= Time.deltaTime;


        if (timeToSpawn <= 0 && enemyCount <= 0)
        {
            int maxEnemy = level * maxSpawnEnemy;
            

            while (enemyCount < maxEnemy)
            {
                timeToSpawn = spawnRate;
                var enemyToSpawn = EnemyToSpawn();
                var spawnPos = new Vector3(Random.Range(-maxSpawnXPos, maxSpawnXPos), Random.Range(transform.position.y, maxSpawnYPos), transform.position.z);
                Instantiate(enemyToSpawn, spawnPos, transform.rotation);
                enemyCount++;
            }


        }
    }

    private GameObject EnemyToSpawn()
    {

        GameObject enemy = enemies[0];

        var chance = Random.Range(0, level);
        if (chance >= 3)
        {
            enemy = enemies[1];
        }

        return enemy;
    }

    public void AddXP(int points)
    {
        xp += points;
        if (xp >= nextLevel)
        {
            level++;
            nextLevel *= level;
            xp = 0;

        }
    }

    public void RemoveEnemy()
    {
        enemyCount--;
    }
}
