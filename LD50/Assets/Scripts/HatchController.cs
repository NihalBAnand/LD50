using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchController : InteractableGeneric
{
    private bool activated;
    public GameObject logText;

    public override void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Camera.main.transform.position = GameObject.Find("hull").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);

            if (!logText.GetComponent<EntryController>().firstTrap) logText.GetComponent<EntryController>().firstTrap = true;

            player.GetComponent<PlayerController>().atHull = true;
        }
        else
        {
            activated = false;
            Camera.main.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            Camera.main.transform.position = GameObject.Find("Player").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            GameObject.Find("Player").GetComponent<PlayerController>().interacting = false;

            player.GetComponent<PlayerController>().atHull = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        logText = GameObject.Find("LogText");
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
