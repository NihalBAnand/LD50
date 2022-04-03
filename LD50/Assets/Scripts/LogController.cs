using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LogController : InteractableGeneric
{

    private bool activated;
    public GameObject log; 
    public override void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;

            log.GetComponent<Image>().enabled = true;

            log.transform.Find("LogText").GetComponent<Text>().enabled = true;

            log.transform.Find("BackButton").GetComponent<Button>().enabled = true;
            log.transform.Find("BackButton").GetComponent<Image>().enabled = true;

            log.transform.Find("ForwardButton").GetComponent<Button>().enabled = true;
            log.transform.Find("ForwardButton").GetComponent<Image>().enabled = true;

            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Camera.main.transform.position = new Vector3(10000, 10000, 3);
        }
        else
        {
            activated = false;

            log.GetComponent<Image>().enabled = false;

            log.transform.Find("LogText").GetComponent<Text>().enabled = false;

            log.transform.Find("BackButton").GetComponent<Button>().enabled = false;
            log.transform.Find("BackButton").GetComponent<Image>().enabled = false;

            log.transform.Find("ForwardButton").GetComponent<Button>().enabled = false;
            log.transform.Find("ForwardButton").GetComponent<Image>().enabled = false;

            Camera.main.transform.parent = player.transform;
            Camera.main.transform.position = player.transform.position + new Vector3(0, 0, -10);
        }
    }

    // Start is called before the first frame update
    void Start() 
    {

        activated = false;

        log = GameObject.Find("Log");

        log.GetComponent<Image>().enabled = false;

        log.transform.Find("LogText").GetComponent<Text>().enabled = false;

        log.transform.Find("BackButton").GetComponent<Button>().enabled = false;
        log.transform.Find("BackButton").GetComponent<Image>().enabled = false;

        log.transform.Find("ForwardButton").GetComponent<Button>().enabled = false;
        log.transform.Find("ForwardButton").GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}