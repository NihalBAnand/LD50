using System.Collections;
using System.Collections.Generic;
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
                log.SetActive(true);

            }
            else
            {
                activated = false;
                log.SetActive(false);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            activated = false;
            log = GameObject.Find("Log");
            log.SetActive(false);
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }