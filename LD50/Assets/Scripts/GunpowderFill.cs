using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunpowderFill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannon;

    private bool running;
    void Start()
    {
        cannon = GameObject.Find("Cannon");

        running = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        if (!running)
            StartCoroutine(fillGunpowder());
    }
    IEnumerator fillGunpowder()
    {
        running = true;
        GameObject.Find("GunpowderLevel").GetComponent<PowderLevelController>().addGunpowder();
        yield return new WaitForSeconds(0.5f);
        running = false;
    }
}