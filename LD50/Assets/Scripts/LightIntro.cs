using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIntro : InteractableGeneric
{
    private bool activated;

    public GameObject mainLight;
    public GameObject player;

    override public void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Camera.main.transform.position = GameObject.Find("LightMinigame").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);

        }
        else
        {
            activated = false;
            Camera.main.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            Camera.main.transform.position = GameObject.Find("Player").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            GameObject.Find("Player").GetComponent<PlayerController>().interacting = false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        mainLight = GameObject.Find("Main Light");
        player = GameObject.Find("Player");
        StartCoroutine(lightDim());
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("Light Intesity").GetComponent<Text>().text = mainLight.GetComponent<Light>().intensity.ToString();
        //GameObject.Find("Cores").GetComponent<Text>().text = GameObject.Find("Player").GetComponent<PlayerController>().cores.ToString();
    }

    IEnumerator lightDim()
    {
        yield return new WaitForSeconds(30.0f);
        mainLight.GetComponent<Light>().intensity -= 1;
        Debug.Log(mainLight.GetComponent<Light>().intensity);
    
    }
}
