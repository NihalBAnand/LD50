using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private GameObject player;
    private GameObject light;
    private UnityEngine.UI.Text indicator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        light = GameObject.Find("Main light");
        indicator = GameObject.Find("MaxLightIndicator").GetComponent<UnityEngine.UI.Text>();

        StartCoroutine(lightDecay());
    }

    // Update is called once per frame
    void Update()
    {
        if (light.GetComponent<Light>().intensity > 8)
        {
            light.GetComponent<Light>().intensity = 8;
        }
        if (light.GetComponent<Light>().intensity == 8 && player.GetComponent<PlayerController>().atLight) 
        {
            indicator.enabled = true;
        }
        else
        {
            indicator.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (player.GetComponent<PlayerController>().cores >= 1 && light.GetComponent<Light>().intensity < 8) 
        {
            player.GetComponent<PlayerController>().cores--;
            light.GetComponent<Light>().intensity += 1;
        }
    }

    IEnumerator lightDecay()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            //50% chance to lower light level
            if (Random.Range(0, 2) == 1)
            {
                light.GetComponent<Light>().intensity -= 1;
            } 
        }
    }
}
