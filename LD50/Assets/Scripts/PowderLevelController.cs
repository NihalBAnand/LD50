using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowderLevelController : MonoBehaviour
{
    public bool cannonStatus;

    public float gunpowderStack;
    public float depletionRate;

    public int enemySpawnFactor;

    public GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        cannonStatus = true;
        gunpowderStack = 100;
        depletionRate = .1f;
        enemySpawnFactor = 2;

        ship = GameObject.Find("ShipController");

        StartCoroutine(depleteCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (gunpowderStack < 1 && cannonStatus)
        {
            cannonStatus = false;
            gunpowderStack = 0;
            ship.GetComponent<ShipController>().enemySpawnChance *= enemySpawnFactor;

        }

        if (gunpowderStack > 100)
            gunpowderStack = 100;
        gameObject.GetComponent<Text>().text = Math.Round(gunpowderStack).ToString();
    }

    public void addGunpowder()
    {
        if (gunpowderStack < 100)
        {
            gunpowderStack += 5;
        }
        else
        {
            gunpowderStack = 100;
        }
    }

    IEnumerator depleteCoroutine()
    {
        while (gunpowderStack > 0)
        {
            gunpowderStack *= 1 - depletionRate;
            yield return new WaitForSeconds(5f);

        }
    }
}
