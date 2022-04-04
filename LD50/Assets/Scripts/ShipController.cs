using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpawnChance = .1f;

    public GameObject[] enemies = new GameObject[3];
    public GameObject winged;
    public GameObject teethy;
    public GameObject slime;

    public GameObject rightSideSpawn;
    public GameObject leftSideSpawn;

    public GameObject logText;
    void Start()
    {
        rightSideSpawn = GameObject.Find("RightSpawnLocation");
        leftSideSpawn = GameObject.Find("LeftSpawnLocation");

        StartCoroutine(spawnEnemies());
        StartCoroutine(lightningChance());
        StartCoroutine(increaseEnemies());

        enemies[0] = winged;
        enemies[1] = teethy;
        enemies[2] = slime;

        logText = GameObject.Find("LogText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedUnscaledTime > 120)
        {
            if (!logText.GetComponent<EntryController>().twomins) logText.GetComponent<EntryController>().twomins = true;
        }

        if (Time.fixedUnscaledTime > 540)
        {
            if (!logText.GetComponent<EntryController>().ninemins) logText.GetComponent<EntryController>().ninemins = true;
        }

        if (Time.fixedUnscaledTime > 600)
        {
            Debug.Log("Game Won!");
        }
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
                    GameObject newEnemy = Instantiate(enemies[Random.Range(0, 3)]);
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

    private IEnumerator flashLightning()
    {
        int numTimes = Random.Range(1, 4);
        GameObject lightning = GameObject.Find("Lightning Flash");
        for (int i = 0; i < numTimes; i++)
        {
            lightning.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            lightning.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator lightningChance()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (Random.Range(0, 3) == 0)
            {
                StartCoroutine(flashLightning());

            }
        }
    }

    IEnumerator increaseEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            enemySpawnChance += 0.01f;
        }
    }
}
