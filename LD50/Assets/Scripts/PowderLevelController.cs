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

    private float powderBarRange;
    private float powderBarMin;

    // Start is called before the first frame update
    void Start()
    {
        cannonStatus = true;
        gunpowderStack = 100;
        depletionRate = .1f;
        enemySpawnFactor = 2;

        ship = GameObject.Find("ShipController");

        StartCoroutine(depleteCoroutine());

        powderBarMin = 220.4576f;
        powderBarRange = 1920 - 191.3589f;
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
        GameObject.Find("GunpowderBar").GetComponent<RectTransform>().offsetMax = new Vector2(-1 * (191.3589f + powderBarRange * (1 - (gunpowderStack / 100))), GameObject.Find("GunpowderBar").GetComponent<RectTransform>().offsetMax.y);
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
