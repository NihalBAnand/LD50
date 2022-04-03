using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingController : InteractableGeneric
{
    public bool activated;

    private GameObject slowCraft;
    private GameObject harmCraft;

    private GameObject player;
    public override void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            slowCraft.SetActive(true);
            harmCraft.SetActive(true);
            Camera.main.transform.parent = transform;
        }
        else
        {
            activated = false;
            slowCraft.SetActive(false);
            harmCraft.SetActive(false);
            Camera.main.transform.parent = player.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activated = false;

        slowCraft = GameObject.Find("CraftSlowTrap");
        harmCraft = GameObject.Find("CraftHarmTrap");

        slowCraft.GetComponent<Button>().onClick.AddListener(craftSlowTrap);
        harmCraft.GetComponent<Button>().onClick.AddListener(craftHarmTrap);

        slowCraft.SetActive(false);
        harmCraft.SetActive(false);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        slowCraft.GetComponent<Button>().interactable = player.GetComponent<PlayerController>().tars >= 5;
        harmCraft.GetComponent<Button>().interactable = player.GetComponent<PlayerController>().teeth >= 5;
    }

    void craftHarmTrap()
    {
        player.GetComponent<PlayerController>().teeth -= 5;
        player.GetComponent<PlayerController>().harmTraps += 1;
    }

    void craftSlowTrap()
    {
        player.GetComponent<PlayerController>().tars -= 5;
        player.GetComponent<PlayerController>().slowTraps += 1;
    }
}
