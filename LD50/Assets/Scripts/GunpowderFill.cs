using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunpowderFill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannon;
    void Start()
    {
        cannon = GameObject.Find("Cannon");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        StartCoroutine(fillGunpowder());
    }
    IEnumerator fillGunpowder()
    {
        Debug.Log(cannon.GetComponent<CannonController>().gunpowderStack);
        cannon.GetComponent<CannonController>().addGunpowder();
        yield return new WaitForSeconds(1.0f);
        
    }
}