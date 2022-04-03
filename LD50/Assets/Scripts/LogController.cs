using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : InteractableGeneric
{

        private bool activated;
        public override void Interaction(GameObject player)
        {
            if (!activated)
            {
                activated = true;
                Camera.main.transform.parent = GameObject.Find("Center").transform;
                Camera.main.transform.position = GameObject.Find("Log").transform.position;
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
        }

        // Update is called once per frame
        void Update()
        {

        }
    }