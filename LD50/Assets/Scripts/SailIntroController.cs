using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailIntroController : InteractableGeneric
{
    private bool activated;
    // Start is called before the first frame update

    public GameObject logText;
    void Start()
    {
        activated = false;

        //logText = GameObject.Find("LogText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Takes player back and forth from the sail minigame when interacted with
    override public void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Camera.main.transform.position = GameObject.Find("sail").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);

            player.GetComponent<PlayerController>().atSail = true;

            if (!logText.GetComponent<EntryController>().firstSail) logText.GetComponent<EntryController>().firstSail = true;
        }
        else
        {
            activated = false;
            Camera.main.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            Camera.main.transform.position = GameObject.Find("Player").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            GameObject.Find("Player").GetComponent<PlayerController>().interacting = false;

            player.GetComponent<PlayerController>().atSail = false;
        }
    }
}
