using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CannonController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool cannonStatus;
    public float gunpowderStack;
    public float depletionRate;
    public int enemySpawnFactor;
    public GameObject ship;

    void Start()
    {
        cannonStatus = true;
        gunpowderStack = 100;
        depletionRate = .1f;
        enemySpawnFactor = 2;
        StartCoroutine(depleteCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        if (gunpowderStack< 1)
        {
            cannonStatus = false;
            gunpowderStack = 0;
            ship.GetComponent<ShipController>().enemySpawnChance *=enemySpawnFactor;
            
        }
        
    }
    IEnumerator depleteCoroutine()
    {
        while (gunpowderStack>0)
        {
            gunpowderStack *= 1 - depletionRate;
            yield return new WaitForSeconds(1.0f);
            
        }
    }

}
