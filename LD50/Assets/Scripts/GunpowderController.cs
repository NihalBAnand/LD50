using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunpowderController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cannon;
    void Start()
    {
        cannon = GameObject.Find("Cannon");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
