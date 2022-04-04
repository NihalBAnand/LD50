using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainLight;
    GameObject player;
    void Start()
    {
        mainLight = GameObject.Find("Main Light");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        if (mainLight.GetComponent<Light>().intensity < 8)
        {
            try
            {
                mainLight.GetComponent<Light>().intensity += 1;
                player.GetComponent<PlayerController>().cores -= 1;
            }
            catch
            {
                Debug.Log("LOL");
            }
        }

    }
}
