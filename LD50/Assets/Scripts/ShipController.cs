using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpawnChance = .1f;

    public GameObject enemy;

    public GameObject rightSideSpawn;
    public GameObject leftSideSpawn;
    void Start()
    {
        rightSideSpawn = GameObject.Find("RightSpawnLocation");
        leftSideSpawn = GameObject.Find("LeftSpawnLocation");

        StartCoroutine(spawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int spawnAttempt = Random.Range(0, 101);
            if (spawnAttempt <= 100 * enemySpawnChance)
            {
                int numSpawned = Random.Range(1, 6);
                for (int i = 0; i < numSpawned; i++)
                {
                    GameObject newEnemy = Instantiate(enemy);
                    bool rightSide = Random.Range(0, 2) == 1;
                    if (rightSide)
                    {
                        newEnemy.transform.position = rightSideSpawn.transform.position;
                    }
                    else
                    {
                        newEnemy.transform.position = leftSideSpawn.transform.position;
                    }
                }
            }
        }
    }
}
